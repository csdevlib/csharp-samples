using BackOffice.Shared.Domain.ValueObjects;
using BackOffice.Shared.Extensions;
using MediatR;

namespace BackOffice.Shared.Domain
{
    public abstract record DomainEvent : INotification
    {
        public string AggregateId { get; }
        public string EventId { get; }
        public string OccurredOn { get; }

        protected DomainEvent() { }

        protected DomainEvent(string aggregateId,
                              string eventId,
                              string occurredOn)
        {
            AggregateId = aggregateId ??  throw new ArgumentNullException(nameof(aggregateId));
            EventId = eventId ?? Uuid.Random().Value;
            OccurredOn = occurredOn ?? DateTime.Now.DateToString();
        }

        public abstract string EventName();

        public abstract Dictionary<string, string> ToPrimitives();

        public abstract DomainEvent FromPrimitives(string aggregateId,
                                                   Dictionary<string, string> body,
                                                   string eventId,
                                                   string occurredOn);
    }
}
