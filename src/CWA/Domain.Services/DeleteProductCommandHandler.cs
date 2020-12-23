using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public DeleteProductCommandHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            Repository.Product.DeleteProduct(request.ProductDeleted);
            await Repository.SaveAsync();
            return Unit.Value;
        }

        public void Validate(DeleteProductCommand request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");

            if (request.ProductDeleted == null)
                throw new ArgumentNullException("Product object can not be null.");
        }
    }
}
