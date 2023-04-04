using ESStore.Infrastructure.Data.Database.Tables;
using MongoDB.Driver;

namespace ESStore.Infrastructure.Data.Database
{
    public interface IEventStoreContext
    {
        IMongoCollection<EventStoreTable> EventStore { get; }
    }
}
