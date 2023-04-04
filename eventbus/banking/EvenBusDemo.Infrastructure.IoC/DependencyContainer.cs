using MediatR;
using EventBusDemo.Banking.Application.Interfaces;
using EventBusDemo.Banking.Application.Services;
using EventBusDemo.Banking.Domain.Commands;
using EventBusDemo.Banking.Domain.Commands.Handlers;
using EventBusDemo.Banking.Domain.Interfaces;
using EventBusDemo.Transfer.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using EventBusDemo.Transfer.Domain.Events;
using EventBusDemo.Transfer.Domain.Events.Handlers;
using EventBusDemo.Banking.Infrastructure.Data.Context;
using EventBusDemo.Transfer.Infrastructure.Data.Context;
using EventBusDemo.Banking.Infrastructure.Data.Repository;
using EventBusDemo.Transfer.Domain.Interfaces;
using EventBusDemo.Transfer.Infrastructure.Data.Repository;
using EvenBusDemo.Infrastructure.EventBus.Common.Bus;
using EvenBusDemo.Infrastructure.EventBus.Infrastructure.RabbitMQ;

namespace EventBusDemo.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            services.AddTransient<TransferCreatedEventHandler>();

            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, CreateTransferCommandHandler>();

            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferCreatedEventHandler>();

            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<ITransferService, TransferService>();

            services.AddTransient<BankingDbContext>();

            services.AddTransient<TransferDbContext>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<ITransferRepository, TransferRepository>();
        }
    }
}

