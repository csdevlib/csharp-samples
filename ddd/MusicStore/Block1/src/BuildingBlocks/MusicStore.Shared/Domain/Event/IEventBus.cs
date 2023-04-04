namespace MusicStore.Shared.Domain.Bus.Event
{
    public interface IEventBus
    {
        Task Publish(List<DomainEvent> events);
    }
}
