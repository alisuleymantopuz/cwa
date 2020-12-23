using MediatR;
using System.Collections.Generic;

namespace Domain.Services
{
    public class GetProductsTagsQuery : IRequest<IEnumerable<ProductsTags>>
    {

    }
}
