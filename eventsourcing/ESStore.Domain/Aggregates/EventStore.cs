using BeyondNet.Patterns.NetDdd.Core.Impl;
using BeyondNet.Patterns.NetDdd.Core.Impl.ValueObjects;
using System;

namespace ESStore.Domain.Aggregates
{
    public class EventStore : AggregateRoot
    {
        public EventValue Event { get; private set; }
        public StreamValue Stream { get; private set; }
        public AuditValueObject Audit { get; private set; }
        public EEventStoreStatus Status { get; private set; }

        private EventStore(EventValue eventValue, 
                           StreamValue streamValue, 
                           string creator)
        {

            var createdDate = DateTime.UtcNow;
            Event = eventValue;
            Stream = streamValue;
            Audit = AuditValueObject.Create(createdDate, creator);
            Status = EEventStoreStatus.Active;
        }

        public static EventStore Create(EventValue eventValue,
                                        StreamValue streamValue,
                                        string creator)
        {
            return new EventStore(eventValue, streamValue, creator);
        }
    }
}
