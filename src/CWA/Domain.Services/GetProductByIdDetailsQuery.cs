using MediatR;
using System;

namespace Domain.Services
{
    public class GetProductByIdDetailsQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
