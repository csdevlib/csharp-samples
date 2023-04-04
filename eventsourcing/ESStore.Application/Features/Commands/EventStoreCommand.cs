
using BeyondNet.Patterns.NetDdd.Core.Interfaces;
using MediatR;

namespace ESStore.Application.Features.Commands
{
    public class EventStoreCommand : IRequest<bool>
    {
        public IAggregateRoot Aggregate { get; set; }
    }
}
