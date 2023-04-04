using System.Collections.Generic;
using System.Threading.Tasks;
using ESStore.Domain.Aggregates;

namespace ESStore.Application.Contracts.Store
{
    public interface IEventStore : IEventStoreReader
    {
        Task<IEnumerable<EventStore>> Save(string streamId, string streamType, IEnumerable<object> events, long expectedVersion, IDictionary<string, object> metadata);
    }
}
