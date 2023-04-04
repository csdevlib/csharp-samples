using BackOffice.Application.Events.Integration.Interfaces;
using Microsoft.Extensions.Logging;
using SkillMap.EventBus.Events;
using SkillMap.EventBus.Interfaces;

namespace BackOffice.Application.Events
{
    public class BackOfficeIntegrationEventService : IBackOfficeIntegrationEventService
    {
        private readonly IEventBus eventBus;

        private readonly ILogger<BackOfficeIntegrationEventService> logger;

        public BackOfficeIntegrationEventService(IEventBus eventBus, ILogger<BackOfficeIntegrationEventService> logger)
        {
            this.eventBus = eventBus;

            this.logger = logger;
        }

        public Task AddAndSaveEventAsync(IntegrationEvent evt)
        {
            logger.LogInformation("----- Enqueuing integration event {IntegrationEventId} to repository ({@DomainEventId})", evt.IntegrationEventId, evt.DomainEventId);

            throw new NotImplementedException();
        }

        public Task PublishEventsThroughEventBusAsync(string transactionId)
        {
            throw new NotImplementedException();
        }
    }
}
