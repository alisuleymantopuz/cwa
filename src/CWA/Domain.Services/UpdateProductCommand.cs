using MediatR;
using System;

namespace Domain.Services
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public Product ProductUpdated { get; set; }
    }
}
