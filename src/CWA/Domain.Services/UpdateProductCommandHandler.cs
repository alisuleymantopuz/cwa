using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public UpdateProductCommandHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            var ProductEntity = await Repository.Product.GetProductByIdAsync(request.Id);
            if (ProductEntity == null)
                throw new Exception("Record not found.");

            Repository.Product.UpdateProduct(request.ProductUpdated);
            await Repository.SaveAsync();
            return Unit.Value;
        }

        public void Validate(UpdateProductCommand request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");

            if (request.ProductUpdated == null)
                throw new ArgumentNullException("Product object can not be null.");
        }
    }
}
