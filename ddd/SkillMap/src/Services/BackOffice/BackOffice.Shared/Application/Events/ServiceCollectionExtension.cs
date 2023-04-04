using AutoMapper;
using BackOffice.Shared.Application.Command;
using BackOffice.Shared.Domain;
using BackOffice.Shared.Events;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BackOffice.Shared.Application.Events
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBaseApplication(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);

            services.AddValidatorsFromAssemblies(assemblies);

            services.AddMediatR(assemblies);

            services.AddBehaviors();

            return services;
        }

        public static IServiceCollection AddBehaviors(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionalBehavior<,>));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(DomainEventDispatcherBehavior<,>));

            return services;
        }

        public static IServiceCollection AddEventDispatcher<TDomainEvent, TEvent>(this IServiceCollection services, Action<IMappingExpression<TDomainEvent, TEvent>> mapper = null)
            where TDomainEvent : DomainEvent
            where TEvent : @Event
        {
            if (mapper != null)
            {
                services.PostConfigure<MapperConfigurationExpression>((options) => mapper(options.CreateMap<TDomainEvent, TEvent>()));
            }
            else
            {
                services.PostConfigure<MapperConfigurationExpression>((options) => options.CreateMap<TDomainEvent, TEvent>());
            }

            return services.AddTransient<INotificationHandler<TDomainEvent>, EventDispatcher<TDomainEvent, TEvent>>();
        }

        public static IServiceCollection AddCommandDispatcher<TDomainEvent, TCommand>(this IServiceCollection services, Action<IMappingExpression<TDomainEvent, TCommand>> mapper = null, Func<TDomainEvent, bool> when = null)
            where TDomainEvent : DomainEvent
            where TCommand : CommandBase
        {
            if (mapper != null)
            {
                services.PostConfigure<MapperConfigurationExpression>((options) => mapper(options.CreateMap<TDomainEvent, TCommand>()));
            }
            else
            {
                services.PostConfigure<MapperConfigurationExpression>((options) => options.CreateMap<TDomainEvent, TCommand>());
            }
            return services.AddTransient<INotificationHandler<TDomainEvent>, CommandDispatcher<TDomainEvent, TCommand>>(provider => new CommandDispatcher<TDomainEvent, TCommand>(provider.GetRequiredService<IMediator>(), provider.GetRequiredService<IMapper>(), when));
        }
    }
}
