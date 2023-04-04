using System.Net;

namespace MusicStore.Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<IdeaController> _logger;

        public IdeaController(IMediator mediator, ILogger<IdeaController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IdeaModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<IdeaModel>>> Get()
        {
            var result = await _mediator.Send(new GetIdeaListQuery());

            if (!result.Any()) NotFound();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IdeaModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<IdeaModel>>> GetById(string id)
        {
            var result = await _mediator.Send(new GetIdeaByIdQuery(id));

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> Post([FromBody] CreateIdeaCommand createIdeaCommand)
        {

            var result = await _mediator.Send(createIdeaCommand);

            if (!result) BadRequest();

            return Ok();
        }
    }
}
