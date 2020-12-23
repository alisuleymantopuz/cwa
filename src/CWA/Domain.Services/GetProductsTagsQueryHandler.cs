using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GetProductsTagsQueryHandler : IRequestHandler<GetProductsTagsQuery, IEnumerable<ProductsTags>>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public GetProductsTagsQueryHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }
        public async Task<IEnumerable<ProductsTags>> Handle(GetProductsTagsQuery request, CancellationToken cancellationToken)
        {
            var tag = await Repository.ProductsTags.GetAllProductsTagsAsync();
            Logger.LogInfo($"product tags returned from database.");
            return tag;
        }
    }
}
