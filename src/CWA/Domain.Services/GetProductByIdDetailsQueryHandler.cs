using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GetProductByIdDetailsQueryHandler : IRequestHandler<GetProductByIdDetailsQuery, Product>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public GetProductByIdDetailsQueryHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }
        public async Task<Product> Handle(GetProductByIdDetailsQuery request, CancellationToken cancellationToken)
        {
            var tag = await Repository.Product.GetProductWithDetailsAsync(request.Id);
            Logger.LogInfo($"product returned from database.");
            return tag;
        }
    }
}
