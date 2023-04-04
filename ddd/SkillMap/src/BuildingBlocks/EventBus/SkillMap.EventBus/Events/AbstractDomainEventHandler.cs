namespace SkillMap.EventBus.Events;

public abstract class AbstractDomainEventHandler<TEvent> : NotificationHandler<TEvent> where TEvent : IDomainEvent
{
    protected readonly ILogger<TEvent> logger;

    protected readonly IMediator mediator;

    public AbstractDomainEventHandler(ILogger<TEvent> logger, IMediator mediator)
    {
        this.logger = logger;

        this.mediator = mediator;
    }

    protected abstract override void Handle(TEvent @event);
}
