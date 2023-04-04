using System.Threading.Tasks;

namespace BackOffice.Shared.Domain.Interfaces
{
    public interface IDomainEventPublisher
    {
        public Task Publish(object @event);
    }
}
