using EvenBusDemo.Infrastructure.EventBus.Common.Bus;
using EventBusDemo.Transfer.Domain.Interfaces;
using EventBusDemo.Transfer.Domain.Models;
using System;
using System.Threading.Tasks;

namespace EventBusDemo.Transfer.Domain.Events.Handlers
{
    public class TransferCreatedEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferCreatedEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                Amount = @event.Amount
            });

            return Task.CompletedTask;
        }
    }
}
