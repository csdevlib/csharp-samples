using EvenBusDemo.Infrastructure.EventBus.Common.Events;

namespace EventBusDemo.Banking.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public int From { get; protected set; }

        public int To { get; protected set; }

        public decimal Amount { get; protected set; }

        public TransferCreatedEvent(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}

