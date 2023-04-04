using EventBusDemo.Transfer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventBusDemo.Transfer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
 
        private readonly ILogger<TransferController> _logger;
        
        private readonly ITransferService _transferService;

        public TransferController(ILogger<TransferController> logger, ITransferService transferService)
        {
            _logger = logger;
            
            _transferService = transferService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_transferService.GetTransfersLogs());
        }
    }
}
