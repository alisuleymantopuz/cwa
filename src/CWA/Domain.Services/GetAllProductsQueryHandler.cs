using Domain.Infrastructure.Logging;
using Domain.Pagination;
using Domain.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedList<Product>>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public GetAllProductsQueryHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }
        public async Task<PagedList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            Validate(request);
            var products = await Repository.Product.GetProductsAsync(request.Parameters);
            Logger.LogInfo($"all products returned from database.");
            return products;
        }

        private void Validate(GetAllProductsQuery request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");

            if (request.Parameters == null)
                throw new ArgumentNullException("Parameters object can not be null.");
        }
    }
}
