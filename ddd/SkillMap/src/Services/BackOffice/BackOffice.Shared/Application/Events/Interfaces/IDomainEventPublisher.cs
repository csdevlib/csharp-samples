namespace BackOffice.Shared.Application.Events.Interfaces
{
    public interface IDomainEventPublisher
    {
        public Task Publish(object @event);
    }
}
