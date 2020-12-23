using MediatR;
using System;

namespace Domain.Services
{
    public class GetTagByIdDetailsQuery : IRequest<Tag>
    {
        public Guid Id { get; set; }
    }
}
