using Api.Hubs;
using Api.Models;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.SignalR; 
using System.Threading.Tasks;

namespace Api.JobHelpers
{
    public interface IImportJobHelper
    {
        Task Import(ImportProductDto product);
    }

    public class ImportJobHelper : IImportJobHelper
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<MessageHub> _messageHubContext;

        public ImportJobHelper(IMediator mediator, IHubContext<MessageHub> messageHubContext)
        {
            _mediator = mediator;
            _messageHubContext = messageHubContext;
        }
        public async Task Import(ImportProductDto product)
        {
            await _mediator.Send(new ImportProductCommand() { ProductCount = product.ProductCount });
            await _messageHubContext.Clients.All.SendAsync("ReceiveMessage", $"New products added.");
        }
    }
}
