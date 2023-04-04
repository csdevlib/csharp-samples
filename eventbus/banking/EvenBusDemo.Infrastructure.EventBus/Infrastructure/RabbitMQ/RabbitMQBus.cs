using EvenBusDemo.Infrastructure.EventBus.Common.Bus;
using EvenBusDemo.Infrastructure.EventBus.Common.Commands;
using EvenBusDemo.Infrastructure.EventBus.Common.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenBusDemo.Infrastructure.EventBus.Infrastructure.RabbitMQ
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;

        private readonly Dictionary<string, List<Type>> _handlers;

        private readonly List<Type> _eventTypes;

        private readonly IServiceScopeFactory _serviceScopefactory;

        public RabbitMQBus(IMediator mediator, IServiceScopeFactory serviceScopefactory)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            _serviceScopefactory = serviceScopefactory ?? throw new ArgumentNullException(nameof(serviceScopefactory));

            _handlers = new Dictionary<string, List<Type>>();

            _eventTypes = new List<Type>();
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        //TODO: Pending refactor to custom options and address, encoding, etc.
        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var eventName = @event.GetType().Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var message = JsonConvert.SerializeObject(@event);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", eventName, null, body);
        }

        // TODO: Pending Refactor, common logic
        public void Subscribe<T, THandler>()
            where T : Event
            where THandler : IEventHandler<T>
        {
            var eventName = typeof(T).Name;

            var handlerType = typeof(THandler);

            if (!_eventTypes.Contains(typeof(T))) _eventTypes.Add(typeof(T));

            if (!_handlers.ContainsKey(eventName)) _handlers.Add(eventName, new List<Type>());

            if (_handlers[eventName].Any(s => s.GetType() == handlerType))
                throw new ArgumentException($"Handler type {handlerType.Name} already is registered for {eventName}");

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        //TODO: IoC
        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost", DispatchConsumersAsync = true };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var eventName = typeof(T).Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += Consumer_Received;

            channel.BasicConsume(eventName, true, consumer);

        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;

            var message = Encoding.UTF8.GetString(e.Body.Span);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {
                var subscriptions = _handlers[eventName];

                using (var scope = _serviceScopefactory.CreateScope())
                {
                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(subscription);

                        if (handler == null) continue;

                        var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);

                        var @event = JsonConvert.DeserializeObject(message, eventType);

                        var concretType = typeof(IEventHandler<>).MakeGenericType(eventType);

                        await (Task)concretType.GetMethod("handle").Invoke(handler, new object[] { @event });
                    }
                }
                
            }
        }

        
    }
}
