using ESStore.Application.Contracts.Store;
using ESStore.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESStore.Infrastructure.Data
{
    public class MongoDbEventStoreReader : IEventStoreReader
    {
        public Task<bool> Exists(string streamId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventStore>> Read(string streamId)
        {
            throw new NotImplementedException();
        }
    }
}
