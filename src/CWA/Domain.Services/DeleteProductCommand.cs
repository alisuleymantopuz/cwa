using MediatR;

namespace Domain.Services
{
    public class DeleteProductCommand : IRequest
    {
        public Product ProductDeleted { get; set; }
    }
}
