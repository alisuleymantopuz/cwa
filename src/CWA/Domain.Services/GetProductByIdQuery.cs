using MediatR;
using System;

namespace Domain.Services
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
