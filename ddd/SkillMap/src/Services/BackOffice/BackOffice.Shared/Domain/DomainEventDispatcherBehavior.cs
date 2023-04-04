using BackOffice.Shared.Domain.Interfaces;
using MediatR;

namespace BackOffice.Shared.Domain
{
    public class DomainEventDispatcherBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IDomainEventSource _source;
        private readonly IDomainEventPublisher _publisher;

        public DomainEventDispatcherBehavior(IDomainEventSource source,
                                             IDomainEventPublisher publisher)
        {
            _source = source;
            _publisher = publisher;
        }

        public async Task<TResponse> Handle(TRequest command,
                                            CancellationToken cancellationToken,
                                            RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            var domainEvents = _source.Get();

            foreach (var @event in domainEvents)
            {
                await _publisher.Publish(@event);
            }

            return response;
        }
    }
}
