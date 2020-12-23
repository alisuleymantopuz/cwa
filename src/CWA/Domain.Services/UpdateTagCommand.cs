using MediatR;
using System;

namespace Domain.Services
{
    public class UpdateTagCommand : IRequest
    {
        public Guid Id { get; set; }
        public Tag TagUpdated { get; set; }
    }
}
