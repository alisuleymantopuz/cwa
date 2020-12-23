using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AddTagToProductCommandHandler : IRequestHandler<AddTagToProductCommand>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public AddTagToProductCommandHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }

        public async Task<Unit> Handle(AddTagToProductCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            var productstags = await Repository.ProductsTags.GetProductsTagsAsync(request.ProductId, request.TagId);
            if (productstags != null)
                throw new InvalidOperationException("Product tag match is already available.");
            Repository.ProductsTags.CreateProductsTags(new ProductsTags { ProductId = request.ProductId, TagId = request.TagId });
            await Repository.SaveAsync();
            return Unit.Value;
        }

        public void Validate(AddTagToProductCommand request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");
        }
    }
}
