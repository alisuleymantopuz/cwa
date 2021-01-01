using MediatR;

namespace Domain.Services
{
    public class ImportProductCommand : IRequest
    {
        public int ProductCount { get; set; } 
    }
}
