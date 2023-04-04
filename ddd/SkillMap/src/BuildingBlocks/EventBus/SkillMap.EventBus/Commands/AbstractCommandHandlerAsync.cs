using MediatR;

namespace SkillMap.EventBus.Commands
{
    public abstract class AbstractCommandHandlerAsync<TRequest> : AsyncRequestHandler<TRequest>
                                                                  where TRequest : AbstractCommand
    {
        private readonly IMediator mediator;


        public AbstractCommandHandlerAsync(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Publish(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events)
            {
                await mediator.Publish(@event);
            }
        }

        protected override abstract Task Handle(TRequest command, CancellationToken cancellationToken);
    }
}
