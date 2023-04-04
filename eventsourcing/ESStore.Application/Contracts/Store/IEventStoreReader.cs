using System.Collections.Generic;
using System.Threading.Tasks;
using ESStore.Application.Features.Dtos;
using ESStore.Domain.Aggregates;

namespace ESStore.Application.Contracts.Store
{
    public interface IEventStoreReader
    {
        Task<IEnumerable<EventStore>> ReadByStreamId(string strea);

        Task<bool> Exists(string streamId);
    }
}
