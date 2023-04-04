using BackOffice.Shared.Application.Events.Interfaces;

namespace BackOffice.Shared.Domain
{
    public interface DomainEventSubscriber<TDomain> : IDomainEventSubscriber where TDomain : DomainEvent
    {
        async Task IDomainEventSubscriber.On(DomainEvent @event)
        {
            var msg = @event as TDomain;

            if (msg != null)
                await On(msg);
        }

        Task On(TDomain domainEvent);
    }
}
