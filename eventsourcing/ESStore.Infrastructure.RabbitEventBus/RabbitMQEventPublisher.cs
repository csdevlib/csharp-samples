using ESStore.Application.Contracts.Store;
using System;
using System.Threading.Tasks;

namespace ESStore.Infrastructure.RabbitEventBus
{
    public class RabbitMQEventPublisher : IEventPublisher
    {
        public Task Publish(object @event, string eventId, string streamId)
        {
            throw new NotImplementedException();
        }
    }
}
