namespace SkillMap.EventBus.Events;

public abstract record IntegrationEvent : IIntegrationEvent
{
    public string IntegrationEventId { get; }
    public string DomainEventId { get; }
    public string OccurredOn { get; }

    protected IntegrationEvent()
    {
    }

    protected IntegrationEvent(string integrationEventId, string domainEventId, string occurredOn)
    {
        IntegrationEventId = integrationEventId ?? Guid.NewGuid().ToString();
        DomainEventId = domainEventId ?? throw new ArgumentNullException(nameof(domainEventId));
        OccurredOn = occurredOn ?? DateTime.Now.DateToString();
    }

    public abstract string EventName();
}
