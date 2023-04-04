namespace SkillMap.EventBus.Commands;

public abstract class AbstractCommandHandler<TRequest, TResponse> : RequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    protected readonly IEventBus eventBus;

    public AbstractCommandHandler(IEventBus eventBus)
    {
        this.eventBus = eventBus;
    }

    protected override abstract TResponse Handle(TRequest command);
}

public abstract class AbstractCommandHandler<TRequest> : RequestHandler<TRequest, Unit> where TRequest : IRequest<Unit>
{
    protected readonly IEventBus eventBus;


    public AbstractCommandHandler(IEventBus eventBus)
    {
        this.eventBus = eventBus;
    }

    protected abstract override Unit Handle(TRequest command);
}
