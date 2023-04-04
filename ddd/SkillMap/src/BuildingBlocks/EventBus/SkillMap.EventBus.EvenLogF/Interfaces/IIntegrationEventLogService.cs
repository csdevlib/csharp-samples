namespace SkillMap.EventBus.EvenLogF.Interfaces;

public interface IIntegrationEventLogService
{
    Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(string transactionId);
    Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction transaction);
    Task MarkEventAsPublishedAsync(string eventId);
    Task MarkEventAsInProgressAsync(string eventId);
    Task MarkEventAsFailedAsync(string eventId);
}
