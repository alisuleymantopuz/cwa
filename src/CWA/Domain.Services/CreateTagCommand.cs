using MediatR;

namespace Domain.Services
{
    public class CreateTagCommand : IRequest
    {
        public Tag NewTag { get; set; }
    }
}
