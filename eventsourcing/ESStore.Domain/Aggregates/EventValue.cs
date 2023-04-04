using BeyondNet.Patterns.NetDdd.Core.Impl;
using System;
using System.Collections.Generic;

namespace ESStore.Domain.Aggregates
{
    public class EventValue : AbstractValueObject
    {
        public string EventId { get; set; }
        public string EventType { get; private set; }
        public IDictionary<string, object> EventMetadata { get; private set; }
        public object EventData { get; private set; }
        public DateTime EventDate { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EventId;
            yield return EventType;
            yield return EventMetadata;
            yield return EventData;
        }

        private EventValue(string eventId, string eventType, IDictionary<string, object> eventMetadata, string eventData)
        {
            EventId = eventId;
            EventType = eventType;
            EventMetadata = eventMetadata;
            EventData = eventData;
            EventDate = DateTime.UtcNow;
        }

        public static EventValue Create(string eventId, string eventType, IDictionary<string, object> eventMetadata, string eventData)
        {
            return new EventValue(eventId, eventType, eventMetadata, eventData);
        }
    }
}
