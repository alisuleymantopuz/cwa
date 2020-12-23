using MediatR;
using System;

namespace Domain.Services
{
    public class GetTagByIdQuery : IRequest<Tag>
    {
        public Guid Id { get; set; }
    }
}
