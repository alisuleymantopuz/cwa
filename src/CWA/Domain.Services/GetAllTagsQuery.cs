using Domain.Pagination;
using MediatR; 

namespace Domain.Services
{
    public class GetAllTagsQuery : IRequest<PagedList<Tag>>
    {
        public TagParameters Parameters { get; set; }
    }
}
