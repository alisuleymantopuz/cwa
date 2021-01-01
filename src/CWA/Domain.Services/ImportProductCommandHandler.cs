using Domain.Import;
using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR; 
using System.Linq; 
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ImportProductCommandHandler : IRequestHandler<ImportProductCommand>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public IProductImporter ProductImporter { get; }
        public ImportProductCommandHandler(ILoggerManager logger, IRepositoryWrapper repository, IProductImporter productImporter)
        {
            Repository = repository;
            Logger = logger;
            ProductImporter = productImporter;
        }

        public async Task<Unit> Handle(ImportProductCommand request, CancellationToken cancellationToken)
        {
            var products = await ProductImporter.RetriveImportedProducts(request.ProductCount);
            Repository.Product.Create(products.ToArray());
            await Repository.SaveAsync();
            return Unit.Value;
        }
    }
}
