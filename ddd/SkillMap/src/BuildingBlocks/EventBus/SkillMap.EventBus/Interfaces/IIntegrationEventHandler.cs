namespace SkillMap.EventBus.Interfaces;

public interface IIntegrationEventHandler<in TIntegrationEvent> : INotificationHandler<TIntegrationEvent>
                                                                  where TIntegrationEvent : IIntegrationEvent
{
    Task Handle(TIntegrationEvent @event);
}

