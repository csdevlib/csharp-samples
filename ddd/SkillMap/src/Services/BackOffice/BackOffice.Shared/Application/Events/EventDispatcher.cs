using AutoMapper;
using BackOffice.Shared.Application.Events.Interfaces;
using BackOffice.Shared.Domain;
using MediatR;

namespace BackOffice.Shared.Events
{
    public class EventDispatcher<TDomainEvent, TEvent> : INotificationHandler<TDomainEvent>
     where TDomainEvent : DomainEvent
     where TEvent : @Event

    {
        private readonly IEventPublisher _publisher;
        private readonly IMapper _mapper;

        public EventDispatcher(IEventPublisher publisher, IMapper mapper)
        {
            _publisher = publisher;
            _mapper = mapper;
        }

        public Task Handle(TDomainEvent @event, CancellationToken cancellationToken)
        {
            var integrationEvent = _mapper.Map<TDomainEvent, TEvent>(@event);

            return _publisher.Publish(integrationEvent);
        }
    }
}
