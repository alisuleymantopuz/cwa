using MediatR;
using System.Collections.Generic;

namespace Domain.Services
{
    public class GetAllTagsQuery : IRequest<IEnumerable<Tag>>
    {

    } 
}
