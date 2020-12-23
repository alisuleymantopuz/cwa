using MediatR;
using System;

namespace Domain.Services
{
    public class AddTagToProductCommand : IRequest
    {
        public Guid TagId { get; set; }
        public Guid ProductId { get; set; }
    }
}
