using BackOffice.Application.Events.Integration;
using BackOffice.Domain.Tags.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillMap.EventBus.Events;

namespace BackOffice.Application.Events.Domain
{
    public class TagAddedDomainEventHandler : AbstractDomainEventHandler<TagAddedDomainEvent>
    {
        public TagAddedDomainEventHandler(ILogger<TagAddedDomainEvent> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        protected async override void Handle(TagAddedDomainEvent @event)
        {
            var integrationEvent = new TagAddedIntegrationEvent(@event.Id, @event.Name, @event.Description);

            await mediator.Publish(integrationEvent);
        }
    }
}