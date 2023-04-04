using MediatR;
using EventBusDemo.Banking.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using EvenBusDemo.Infrastructure.EventBus.Common.Bus;

namespace EventBusDemo.Banking.Domain.Commands.Handlers
{
    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public CreateTransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand command, CancellationToken cancellationToken)
        {
            _bus.Publish(new TransferCreatedEvent(command.From, command.To, command.Amount));

            return Task.FromResult(true);
        }
    }
}
