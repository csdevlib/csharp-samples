namespace SkillMap.EventBus.Commands;

public abstract record AbstractCommand : IRequest
{
}

public abstract record AbstractCommand<TResult> : IRequest<TResult>
{
}
