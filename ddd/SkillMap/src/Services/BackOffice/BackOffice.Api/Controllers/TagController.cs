using BackOffice.Application.Commands;
using BackOffice.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackOffice.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TagController : ControllerBase

    {
        private readonly ILogger<TagController> logger;
        private readonly IMediator mediator;

        public TagController(ILogger<TagController> logger,
                             IMediator mediator) 
        {
            this.logger = logger;
            this.mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateTagDto createTagDto)
        {
            var command = new CreateTagCommand(createTagDto.Name, createTagDto.Description);

            logger.LogInformation($"{DateTime.UtcNow.ToShortDateString()} - {DateTime.UtcNow.ToShortTimeString()} " +
                                  $"Sending command: {command.GetType().Name} - " +
                                  $"{nameof(command.Name)}: {command} " +                                    
                                  $"({@command})");

            await mediator.Send(command);

            return Ok();
        }

    }
}
