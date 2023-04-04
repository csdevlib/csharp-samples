namespace MusicStore.Shared.Domain.Bus.Event
{
    public interface IDomainEventSubscriberBase
    {
        Task On(DomainEvent @event);
    }
}
