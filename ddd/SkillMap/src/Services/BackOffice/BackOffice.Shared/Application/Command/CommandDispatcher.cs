using AutoMapper;
using BackOffice.Shared.Domain;
using MediatR;

namespace BackOffice.Shared.Application.Command
{
    public class CommandDispatcher<TDomainEvent, TCommand> : INotificationHandler<TDomainEvent>
      where TDomainEvent : DomainEvent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly Func<TDomainEvent, bool> _when;
        public CommandDispatcher(IMediator mediator, IMapper mapper, Func<TDomainEvent, bool> when = null)
        {
            _mediator = mediator;
            _mapper = mapper;
            _when = when;
        }

        public Task Handle(TDomainEvent @event, CancellationToken cancellationToken)
        {
            if (_when != null && !_when(@event))
            {
                return Task.CompletedTask;
            }

            var command = _mapper.Map<TDomainEvent, TCommand>(@event);

            return _mediator.Send(command);
        }
    }
}
