using Microsoft.Extensions.DependencyInjection;
using ESStore.Infrastructure.Data;
using ESStore.Infrastructure.Data.Database;
using ESStore.Application.Services;
using ESStore.Infrastructure.RabbitEventBus;
using ESStore.Application.Contracts.Persist;
using ESStore.Application.Contracts.Store;
using ESStore.Infrastructure.Store;

namespace ESStore.Infrastructure.IoC
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventStoreContext, EventStoreContext>();
            services.AddSingleton<IEventStoreRepository, EventStoreRepository>();

            services.AddSingleton<IEventStore, MongoDbEventStore>();
            services.AddSingleton<IEventStoreReader, MongoDbEventStoreReader>();
            services.AddSingleton<IAggregateStore,DefaultAggregateStore>();
            services.AddSingleton<IAggregateStoreLoader, DefaultAggregateStoreLoader>();
            
            services.AddSingleton<IEventStoreService, EventStoreService>();
            services.AddSingleton<IEventPublisher, RabbitMQEventPublisher>();

            return services;
        }
    }
}
