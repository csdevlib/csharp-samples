using ESStore.Application.Features.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESStore.Application.Services
{
    public interface IEventStoreService
    {
        Task<bool> Save(CreateEventStoreDto createEventStoreDto);

        Task<IEnumerable<EventDataDto>> Find(EventDataFilterDto filter);
    }
}
