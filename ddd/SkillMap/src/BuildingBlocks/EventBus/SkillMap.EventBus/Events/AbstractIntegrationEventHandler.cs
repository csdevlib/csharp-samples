namespace SkillMap.EventBus.Events;

public abstract class AbstractIntegrationEventHandler<TEvent> : NotificationHandler<TEvent> where TEvent : IntegrationEvent
{
    protected readonly IEventBus eventBus;
    protected readonly ILogger<TEvent> logger;



    public AbstractIntegrationEventHandler(IEventBus eventBus,
                                           ILogger<TEvent> logger)
    {
        this.eventBus = eventBus;
        this.logger = logger;
    }

    protected abstract override void Handle(TEvent @event);
}
