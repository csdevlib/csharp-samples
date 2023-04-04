using BeyondNet.Patterns.NetDdd.Core.Interfaces;

namespace ESStore.Application.Features.Dtos
{
    public class CreateEventStoreDto
    {
        public string AggregateId { get; set; }
        public IAggregateRoot Aggregate { get; set; }
    }
}
