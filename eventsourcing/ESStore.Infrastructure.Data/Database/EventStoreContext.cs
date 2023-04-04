using ESStore.Infrastructure.Data.Database.Tables;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ESStore.Infrastructure.Data.Database
{
    public class EventStoreContext : IEventStoreContext
    {
        public EventStoreContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            EventStore = database.GetCollection<EventStoreTable>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<EventStoreTable> EventStore { get; }
    }
}
