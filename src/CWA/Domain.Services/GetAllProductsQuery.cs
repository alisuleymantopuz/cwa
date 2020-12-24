using Domain.Pagination;
using MediatR;

namespace Domain.Services
{
    public class GetAllProductsQuery : IRequest<PagedList<Product>>
    {

        public ProductParameters Parameters { get; set; }
    }
}
