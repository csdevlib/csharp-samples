using Microsoft.Extensions.Logging;
using SkillMap.EventBus.Events;
using SkillMap.EventBus.Interfaces;

namespace BackOffice.Application.Events.Integration
{
    public class TagCreatedIntegrationEventHandler : AbstractIntegrationEventHandler<TagAddedIntegrationEvent>
    {

        public TagCreatedIntegrationEventHandler(IEventBus eventBus,
                                                 ILogger<TagAddedIntegrationEvent> logger) : base(eventBus, logger)
        {

        }

        protected async override void Handle(TagAddedIntegrationEvent @event)
        {
            eventBus.Publish(@event);
        }
    }
}


