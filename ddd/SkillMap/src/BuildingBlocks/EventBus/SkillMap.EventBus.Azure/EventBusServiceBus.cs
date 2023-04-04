using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace SkillMap.EventBus.Azure
{
    public class EventBusServiceBus : IEventBus, IDisposable
    {
        private readonly string TOPIC_NAME = "SkillMap.BackOffice.EventBus";

        private const string CONTAINER_SCOPE_NAME = "SkillMap.BackOffice.EventBus";

        private const string INTEGRATION_EVENT_SUFFIX = "IntegrationEvent";

        private readonly IServiceBusPersisterConnection serviceBusPersisterConnection;

        private readonly ILogger<EventBusServiceBus> logger;
        
        private readonly IEventBusSubscriptionsManager subsManager;
        
        private readonly IServiceProvider serviceProvider;
        
        private ServiceBusSender sender;
        
        private ServiceBusProcessor processor;
        
        private readonly string subscriptionName;

        public EventBusServiceBus(IServiceBusPersisterConnection serviceBusPersisterConnection,
                                  ILogger<EventBusServiceBus> logger,
                                  IEventBusSubscriptionsManager subsManager,
                                  IServiceProvider serviceProvider,
                                  string subscriptionClientName)
        {
            this.serviceBusPersisterConnection = serviceBusPersisterConnection;

            this.logger = logger;

            this.subsManager = subsManager;

            this.serviceProvider = serviceProvider;

            this.subscriptionName = subscriptionClientName;

            this.sender = serviceBusPersisterConnection.TopicClient.CreateSender(TOPIC_NAME);

            var options = new ServiceBusProcessorOptions { MaxConcurrentCalls = 10, AutoCompleteMessages = false };

            processor = serviceBusPersisterConnection.TopicClient.CreateProcessor(TOPIC_NAME, subscriptionName, options);

            RemoveDefaultRule();

            RegisterSubscriptionClientMessageHandlerAsync().GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            subsManager.Clear();

            processor.CloseAsync().GetAwaiter().GetResult();
        }

        public void Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name.Replace(INTEGRATION_EVENT_SUFFIX, "");
            var jsonMessage = JsonSerializer.Serialize(@event, @event.GetType());
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            var message = new ServiceBusMessage
            {
                MessageId = Guid.NewGuid().ToString(),
                Body = new BinaryData(body),
                Subject = eventName,
            };

            sender.SendMessageAsync(message)
                .GetAwaiter()
                .GetResult();
        }

        public void Subscribe<T, TH>()
            where T : IIntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = typeof(T).Name.Replace(INTEGRATION_EVENT_SUFFIX, "");

            var containsKey = subsManager.HasSubscriptionsForEvent<T>();
            if (!containsKey)
            {
                try
                {
                    serviceBusPersisterConnection.AdministrationClient.CreateRuleAsync(TOPIC_NAME, subscriptionName, new CreateRuleOptions
                    {
                        Filter = new CorrelationRuleFilter() { Subject = eventName },
                        Name = eventName
                    }).GetAwaiter().GetResult();
                }
                catch (ServiceBusException)
                {
                    logger.LogWarning("The messaging entity {eventName} already exists.", eventName);
                }
            }

            logger.LogInformation("Subscribing to event {EventName} with {EventHandler}", eventName, typeof(TH).Name);

            subsManager.AddSubscription<T, TH>();
        }

        public void SubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        {
            logger.LogInformation("Subscribing to dynamic event {EventName} with {EventHandler}", eventName, typeof(TH).Name);

            subsManager.AddDynamicSubscription<TH>(eventName);
        }

        public void Unsubscribe<T, TH>()
            where T : IIntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = typeof(T).Name.Replace(INTEGRATION_EVENT_SUFFIX, "");

            try
            {
                serviceBusPersisterConnection
                    .AdministrationClient
                    .DeleteRuleAsync(TOPIC_NAME, subscriptionName, eventName)
                    .GetAwaiter()
                    .GetResult();
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
            {
                logger.LogWarning("The messaging entity {eventName} Could not be found.", eventName);
            }

            logger.LogInformation("Unsubscribing from event {EventName}", eventName);

            subsManager.RemoveSubscription<T, TH>();
        }

        public void UnsubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        {
            logger.LogInformation("Unsubscribing from dynamic event {EventName}", eventName);

            subsManager.RemoveDynamicSubscription<TH>(eventName);
        }

        private void RemoveDefaultRule()
        {
            try
            {
                serviceBusPersisterConnection
                    .AdministrationClient
                    .DeleteRuleAsync(TOPIC_NAME, subscriptionName, RuleProperties.DefaultRuleName)
                    .GetAwaiter()
                    .GetResult();
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
            {
                logger.LogWarning("The messaging entity {DefaultRuleName} Could not be found.", RuleProperties.DefaultRuleName);
            }
        }

        private async Task<bool> ProcessEvent(string eventName, string message)
        {
            var processed = false;
            if (subsManager.HasSubscriptionsForEvent(eventName))
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var subscriptions = subsManager.GetHandlersForEvent(eventName);
                    foreach (var subscription in subscriptions)
                    {
                        if (subscription.IsDynamic)
                        {
                            var handler = scope.ServiceProvider.GetService(subscription.HandlerType) as IDynamicIntegrationEventHandler;
                            if (handler == null) continue;

                            using dynamic eventData = JsonDocument.Parse(message);
                            await handler.Handle(eventData);
                        }
                        else
                        {
                            var handler = scope.ServiceProvider.GetService(subscription.HandlerType);
                            if (handler == null) continue;
                            var eventType = subsManager.GetEventTypeByName(eventName);
                            var integrationEvent = JsonSerializer.Deserialize(message, eventType);
                            var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                            await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent });
                        }
                    }
                }
                processed = true;
            }
            return processed;
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            var ex = args.Exception;
            var context = args.ErrorSource;

            logger.LogError(ex, "ERROR handling message: {ExceptionMessage} - Context: {@ExceptionContext}", ex.Message, context);

            return Task.CompletedTask;
        }

        private async Task RegisterSubscriptionClientMessageHandlerAsync()
        {
            processor.ProcessMessageAsync +=
                async (args) =>
                {
                    var eventName = $"{args.Message.Subject}{INTEGRATION_EVENT_SUFFIX}";
                    string messageData = args.Message.Body.ToString();

                // Complete the message so that it is not received again.
                if (await ProcessEvent(eventName, messageData))
                    {
                        await args.CompleteMessageAsync(args.Message);
                    }
                };

            processor.ProcessErrorAsync += ErrorHandler;
            
            await processor.StartProcessingAsync();
        }
    }
}
