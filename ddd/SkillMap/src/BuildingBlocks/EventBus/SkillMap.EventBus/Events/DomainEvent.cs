namespace SkillMap.EventBus.Events;

public abstract record DomainEvent : IDomainEvent
{
    public string AggregateId { get; }
    public string EventId { get; }
    public string OccurredOn { get; }

    protected DomainEvent() { }

    protected DomainEvent(string aggregateId,
                          string eventId,
                          string occurredOn)
    {
        AggregateId = aggregateId ?? throw new ArgumentNullException(nameof(aggregateId));
        EventId = eventId ?? Guid.NewGuid().ToString();
        OccurredOn = occurredOn ?? DateTime.Now.DateToString();
    }

    public abstract string EventName();
}
