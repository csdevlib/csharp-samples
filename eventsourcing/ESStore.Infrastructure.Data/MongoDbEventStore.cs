using ESStore.Application.Contracts.Store;
using ESStore.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESStore.Infrastructure.Data
{
    public class MongoDbEventStore : MongoDbEventStoreReader, IEventStore
    {
        public Task<IEnumerable<EventStore>> Save(string streamId, string streamType, IEnumerable<object> events, long expectedVersion, IDictionary<string, object> metadata)
        {
            throw new NotImplementedException();
        }
    }
}
