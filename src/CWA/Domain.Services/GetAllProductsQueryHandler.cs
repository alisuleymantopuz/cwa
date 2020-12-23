using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public GetAllProductsQueryHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await Repository.Product.GetAllProductsAsync();
            Logger.LogInfo($"all products returned from database.");
            return products;
        }
    }
}
