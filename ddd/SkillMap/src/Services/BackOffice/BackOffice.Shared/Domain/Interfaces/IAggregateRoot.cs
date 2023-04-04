namespace BackOffice.Shared.Domain.Interfaces
{
    public interface IAggregateRoot :  IEntity
    {
        List<DomainEvent> PullDomainEvents();

        void AddDomainEvent(DomainEvent domainEvent);

        void RemoveDomainEvent(DomainEvent domainEvent);

        void ClearDomainEvents();
    }
}
