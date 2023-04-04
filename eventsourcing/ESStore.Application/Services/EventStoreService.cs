using AutoMapper;
using ESStore.Application.Features.Commands.CreateEventStore;
using ESStore.Application.Features.Dtos;
using ESStore.Application.Features.Queries.GetEventStores;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESStore.Application.Services
{
    public class EventStoreService : IEventStoreService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<EventStoreService> _logger;

        public EventStoreService(IMediator mediator, IMapper mapper, ILogger<EventStoreService> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<EventDataDto>> Find(EventDataFilterDto filter)
        {
            var queryFilter = _mapper.Map<EvenStoreFilterQuery>(filter);

            return await _mediator.Send(new GetEventStoreQueryList(queryFilter));
        }

        public async Task<bool> Save(CreateEventStoreDto createEventStoreDto)
        {
            var command = _mapper.Map<CreateEventStoreCommand>(createEventStoreDto);

            await _mediator.Send(command);

            return true;
        }
    }
}
