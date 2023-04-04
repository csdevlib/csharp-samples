using BackOffice.Shared.Domain;

namespace BackOffice.Shared.Application.Events.Interfaces
{
    public interface IEventBus
    {
        Task Publish(List<DomainEvent> events);
    }
}
