using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BeyondNet.Patterns.NetDdd.Core.Interfaces;
using ESStore.Application.Contracts.Store;


namespace ESStore.Infrastructure.Store
{
    public class DefaultAggregateStore : DefaultAggregateStoreLoader, IAggregateStore
    {
        private readonly IEventStore _eventStore;

        private readonly IEventPublisher _eventPublisher;

        public DefaultAggregateStore(IEventStore eventStore, IEventPublisher eventPublisher)
            : base(eventStore)
        {
            _eventStore = eventStore;

            _eventPublisher = eventPublisher;
        }

        public async Task Save<TAggregate, T>(TAggregate aggregate, T id, AggregateStoreOptions options = null) where TAggregate : IAggregateRoot
        {
            var streamType = aggregate.GetType().Name;

            var streamId = streamType + "-" + id;

            var events = aggregate.DomainEvents.ToArray();

            var expectedVersion = aggregate.Version - events.Length;

            var metadata = new Dictionary<string, object>
            {
                { "streamid", streamId },
                { "last-version", aggregate.Version },
                { "expected-version", expectedVersion },
                { "options", JsonSerializer.Serialize(options) }
            };

            var eventDatas = await _eventStore.Save(streamId, streamType, events, expectedVersion, metadata);

            if (options != null & options.PublishEvents)
            {
                //TODO: Idea: YAGNI, We can include a new option that choose the service bus (azure, rabbit, etc.) and use a Factory
                foreach (var eventData in eventDatas)
                {
                    await _eventPublisher.Publish(eventData, eventData.Event.EventId, eventData.Stream.StreamId);
                }
            }
        }
    }
}
