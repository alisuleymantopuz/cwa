using MediatR;

namespace Domain.Services
{
    public class DeleteTagCommand : IRequest
    {
        public Tag TagDeleted { get; set; }
    }
}
