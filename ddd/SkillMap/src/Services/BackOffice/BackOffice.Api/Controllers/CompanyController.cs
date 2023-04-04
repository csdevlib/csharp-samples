using BackOffice.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackOffice.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        
        private readonly IMediator _mediator;

        public CompanyController(ILogger<CompanyController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            _logger.LogInformation($"Sending command: {createCompanyCommand.GetType().Name} - " +
                                   $"{nameof(createCompanyCommand.company)}: {createCompanyCommand} " +
                                   $"({@createCompanyCommand})");

            var result = await _mediator.Send(createCompanyCommand);

            return Ok();
        }
    }
}