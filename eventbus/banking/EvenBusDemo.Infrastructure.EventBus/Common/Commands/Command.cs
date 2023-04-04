using EvenBusDemo.Infrastructure.EventBus.Common.Events;
using System;

namespace EvenBusDemo.Infrastructure.EventBus.Common.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
