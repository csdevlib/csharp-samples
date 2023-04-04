using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyondNet.Patterns.NetDdd.Core.Interfaces;
using ESStore.Application.Contracts.Store;

namespace ESStore.Infrastructure.Store
{
    public class DefaultAggregateStoreLoader : IAggregateStoreLoader
    {
        private readonly IEventStoreReader _eventStore;

        public DefaultAggregateStoreLoader(IEventStoreReader eventStore)
        {
            _eventStore = eventStore;
        }

        public Task<bool> Exists<TAggregate, T>(T id) where TAggregate : IAggregateRoot
        {
            var streamId = typeof(TAggregate).Name + "-" + id;

            return _eventStore.Exists(streamId);
        }

        public async Task<TAggregate> Load<TAggregate, T>(T id, AggregateStoreOptions options = null) where TAggregate : IAggregateRoot
        {
            var aggregate = (TAggregate)Activator.CreateInstance(typeof(TAggregate), true);

            var streamId = aggregate.GetType().Name + "-" + id;

            var eventDatas = await _eventStore.Read(streamId);
           
            var enumerable = eventDatas as EventStore[] ?? eventDatas.ToArray();

            if (!enumerable.Any())
            {
                throw new Exception(nameof(TAggregate));
            }

            //TODO: Idea: YAGNI, We can include a new option that choose the servicebus (azure, rabbit, etc.) and use a Factory
            if (options != null & options.PublishEvents)
            {
                foreach (var eventData in enumerable)
                {
                    aggregate.Hydrate(eventData.StreamData as IDomainEvent);
                }
            }

            return aggregate;
        }
    }
}
