using SkillMap.EventBus.Events;

namespace BackOffice.Application.Events.Integration.Interfaces
{
    public interface IBackOfficeIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(string transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}
