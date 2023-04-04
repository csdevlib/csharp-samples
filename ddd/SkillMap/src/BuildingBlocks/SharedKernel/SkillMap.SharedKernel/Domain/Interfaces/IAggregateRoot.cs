namespace SkillMap.SharedKernel.Domain.Interfaces;

public interface IAggregateRoot :  IEntity
{
    int Version { get; }

    public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    IReadOnlyCollection<IDomainEvent> PullDomainEvents();

    void AddDomainEvent(IDomainEvent domainEvent);

    void RemoveDomainEvent(IDomainEvent domainEvent);

    void Load(IEnumerable<IDomainEvent> history);

    void ClearDomainEvents();
}
