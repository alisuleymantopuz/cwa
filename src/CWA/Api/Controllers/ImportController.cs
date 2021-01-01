using Api.Hubs;
using Api.JobHelpers;
using Api.Models;
using AutoMapper;
using Domain.Services;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IHubContext<MessageHub> _messageHubContext;
        private readonly IImportJobHelper _importJobHelper;
        public ImportController(IMediator mediator, IMapper mapper, IHubContext<MessageHub> messageHubContext, IImportJobHelper importJobHelper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _messageHubContext = messageHubContext;
            _importJobHelper = importJobHelper;
        }

        [HttpPost(Name = "import-product")]
        public IActionResult ImportProduct([FromBody] ImportProductDto product)
        {
            var jobId = BackgroundJob.Enqueue(() => _importJobHelper.Import(product));
            return Ok($"Job Id {jobId} for Import Completed.");
        } 
    }
}
