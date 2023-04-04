using System.Threading.Tasks;

namespace ESStore.Application.Contracts.Store
{
    public interface IEventPublisher
    {
        Task Publish(object @event, string eventId, string streamId);
    }
}
