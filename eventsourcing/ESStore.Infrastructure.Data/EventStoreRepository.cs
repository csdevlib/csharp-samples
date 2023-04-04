
using AutoMapper;
using ESStore.Application.Contracts.Persist;
using ESStore.Domain.Aggregates;
using ESStore.Infrastructure.Data.Database;
using ESStore.Infrastructure.Data.Database.Tables;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESStore.Infrastructure.Data
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly IEventStoreContext _context;
        private readonly IMapper _mapper;

        public EventStoreRepository(IEventStoreContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventStore>> GetByAggregateId(string aggregateId)
        {
            var filter = Builders<EventStoreTable>.Filter.Eq(c => c.AggregateId == aggregateId, true);

            var fullCollection = await _context.EventStore.FindAsync<IMongoCollection<EventStoreTable>>(filter);

            var dataTable = await fullCollection.ToListAsync();

            return _mapper.Map<IEnumerable<EventStore>>(dataTable);
        }

        public async Task<IEnumerable<EventStore>> GetByEvent(string eventType)
        {
            var filter = Builders<EventStoreTable>.Filter.Eq(c => c.EventType == eventType, true);

            var fullCollection = await _context.EventStore.FindAsync<IMongoCollection<EventStoreTable>>(filter);
            
            var dataTable = await fullCollection.ToListAsync();

            return _mapper.Map<IEnumerable<EventStore>>(dataTable);
        }

        public async Task<IEnumerable<EventStore>> GetByStream(string streamId)
        {
            var filter = Builders<EventStoreTable>.Filter.Eq(c => c.StreamId == streamId, true);

            var fullCollection = await _context.EventStore.FindAsync<IMongoCollection<EventStoreTable>>(filter);

            var dataTable = await fullCollection.ToListAsync();

            return _mapper.Map<IEnumerable<EventStore>>(dataTable);
        }

        public async Task<bool> Save(EventStore eventStore)
        {
            var dataTable = _mapper.Map<EventStoreTable>(eventStore);

            await _context.EventStore.InsertOneAsync(dataTable);

            return true;
        }
    }
}

