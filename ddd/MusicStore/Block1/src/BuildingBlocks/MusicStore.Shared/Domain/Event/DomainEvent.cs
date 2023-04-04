using MusicStore.Shared.Extensions;

namespace MusicStore.Shared.Domain.Bus.Event
{
    public abstract class DomainEvent
    {
        public string AggregateId { get; }
        public string EventId { get; }
        public string OccurredOn { get; }

        protected DomainEvent(string aggregateId, string eventId, string occurredOn)
        {
            AggregateId = aggregateId;
            EventId = eventId ?? Guid.NewGuid().ToString();
            OccurredOn = occurredOn ?? DateTime.UtcNow.DateToString();
        }

        protected DomainEvent()
        {
        }

        public abstract string EventName();

        public abstract Dictionary<string, string> ToPrimitives();

        public abstract DomainEvent FromPrimitives(string aggregateId, Dictionary<string, string> body, string eventId,
            string occurredOn);
    }
}
