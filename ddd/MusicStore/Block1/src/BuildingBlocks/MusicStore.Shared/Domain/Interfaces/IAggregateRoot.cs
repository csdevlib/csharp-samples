using MusicStore.Shared.Domain.Bus.Event;

namespace MusicStore.Shared.Domain.Interfaces
{
    public interface IAggregateRoot :  IEntity
    {
        List<DomainEvent> PullDomainEvents();

        void AddDomainEvent(DomainEvent domainEvent);

        void RemoveDomainEvent(DomainEvent domainEvent);

        void ClearDomainEvents();
    }
}
