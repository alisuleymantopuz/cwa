using MediatR;
using System.Collections.Generic;

namespace Domain.Services
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }
}
