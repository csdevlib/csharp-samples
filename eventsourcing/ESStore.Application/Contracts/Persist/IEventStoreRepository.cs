using ESStore.Domain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESStore.Application.Contracts.Persist
{
    public interface IEventStoreRepository
    {
        Task<IEnumerable<EventStore>> GetByAggregateId(string aggregateId);

        Task<IEnumerable<EventStore>> GetByEvent(string eventType);

        Task<IEnumerable<EventStore>> GetByStream(string streamType);

        Task<bool> Save(EventStore eventStore);
    }
}
