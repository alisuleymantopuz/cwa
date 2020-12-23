using MediatR;

namespace Domain.Services
{
    public class CreateProductCommand : IRequest
    {
        public Product NewProduct { get; set; }
    }
}
