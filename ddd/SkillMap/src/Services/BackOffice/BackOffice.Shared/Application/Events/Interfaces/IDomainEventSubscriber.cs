using BackOffice.Shared.Domain;

namespace BackOffice.Shared.Application.Events.Interfaces
{
    public interface IDomainEventSubscriber
    {
        Task On(DomainEvent @event);
    }
}
