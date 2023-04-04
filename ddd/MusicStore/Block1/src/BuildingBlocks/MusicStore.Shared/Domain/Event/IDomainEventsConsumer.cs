namespace MusicStore.Shared.Domain.Bus.Event
{
    public interface IDomainEventsConsumer
    {
        Task Consume();
    }
}
