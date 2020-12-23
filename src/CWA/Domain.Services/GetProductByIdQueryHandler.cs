using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public GetProductByIdQueryHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await Repository.Product.GetProductByIdAsync(request.Id);
            Logger.LogInfo($"product returned from database.");
            return tag;
        }
    }
}
