using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public CreateProductCommandHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            Repository.Product.CreateProduct(request.NewProduct);
            await Repository.SaveAsync();
            return Unit.Value;
        }

        public void Validate(CreateProductCommand request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");

            if (request.NewProduct == null)
                throw new ArgumentNullException("Product object can not be null.");
        }
    }
}
