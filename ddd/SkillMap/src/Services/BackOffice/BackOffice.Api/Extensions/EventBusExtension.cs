using SkillMap.EventBus;
using SkillMap.EventBus.Azure;
using SkillMap.EventBus.Azure.Interfaces;
using SkillMap.EventBus.Interfaces;
using SkillMap.EventBus.RabbitMQ.Impl;
using SkillMap.EventBus.RabbitMQ.Interfaces;

namespace BackOffice.Api.Extensions
{
    public static class EventBusExtension
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.BuildServiceProvider();

            if (configuration.GetValue<bool>("AzureServiceBusEnabled"))
            {
                services.AddSingleton<IEventBus, EventBusServiceBus>(sp =>
                {
                    var serviceBusPersisterConnection = sp.GetRequiredService<IServiceBusPersisterConnection>();
                    var logger = sp.GetRequiredService<ILogger<EventBusServiceBus>>();
                    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
                    string subscriptionName = configuration["SubscriptionClientName"];

                    return new EventBusServiceBus(serviceBusPersisterConnection,
                                                  logger,
                                                  eventBusSubcriptionsManager,
                                                  serviceProvider,
                                                  subscriptionName);
                });
            }
            else
            {
                services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
                {
                    var subscriptionClientName = configuration["SubscriptionClientName"];
                    var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                    var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                    {
                        retryCount = int.Parse(configuration["EventBusRetryCount"]);
                    }

                    return new EventBusRabbitMQ(rabbitMQPersistentConnection,
                                                logger,
                                                serviceProvider,
                                                configuration,
                                                eventBusSubcriptionsManager,
                                                subscriptionClientName,
                                                retryCount);
                });
            }

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            return services;
        }
    }
}
