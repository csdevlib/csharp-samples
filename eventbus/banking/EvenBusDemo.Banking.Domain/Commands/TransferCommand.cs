

using EvenBusDemo.Infrastructure.EventBus.Common.Commands;

namespace EventBusDemo.Banking.Domain.Commands
{
    public class TransferCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}
