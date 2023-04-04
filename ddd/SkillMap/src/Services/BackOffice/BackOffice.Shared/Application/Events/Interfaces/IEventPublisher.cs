using BackOffice.Shared.Events;

namespace BackOffice.Shared.Application.Events.Interfaces
{
    public interface IEventPublisher
    {
        Task Publish(@Event @event);
    }
}
