using ESStore.Application.Features.Dtos;
using ESStore.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ESStore.Api.Controllers
{

    [ApiController]
    [Route("api/v1/events")]
    public class EventStoreController : ControllerBase
    {
        private readonly IEventStoreService _evenStoreService;

        public EventStoreController(IEventStoreService evenStoreService)
        {
            _evenStoreService = evenStoreService;
        }

        [HttpPost(Name = "CreateEventStore")]
        [ProducesResponseType(typeof(CreateEventStoreDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Create([FromBody] CreateEventStoreDto createEventStoreDto)
        {
            return Ok(await _evenStoreService.Save(createEventStoreDto));            
        }

        [HttpGet(Name = "GetEventStore")]
        [ProducesResponseType(typeof(IEnumerable<EventDataDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EventDataDto>>> Get(EventDataFilterDto filter)
        {
            return Ok(await _evenStoreService.Find(filter));
        }
    }
}
