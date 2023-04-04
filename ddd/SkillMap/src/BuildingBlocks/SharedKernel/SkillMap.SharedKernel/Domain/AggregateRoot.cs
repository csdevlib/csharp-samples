namespace SkillMap.SharedKernel.Domain;

public abstract class AggregateRoot<T> : AbstractDomainValidator<T>, IAggregateRoot where T : class
{
    private List<IDomainEvent> _domainEvents;

    protected AggregateRoot()
    {
        _domainEvents = new List<IDomainEvent>();
    }

    public int Version { get; private set; } = -1;

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public IReadOnlyCollection<IDomainEvent> PullDomainEvents()
    {
        var events = _domainEvents;
        _domainEvents = new List<IDomainEvent>();

        return events ?? _domainEvents;
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents?.Add(domainEvent);
    }

    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents?.Remove(domainEvent);
    }

    public void Load(IEnumerable<IDomainEvent> history)
    {
        foreach (var e in history)
        {
            AddDomainEvent(e);
            Version++;
        }
        ClearDomainEvents();
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}
