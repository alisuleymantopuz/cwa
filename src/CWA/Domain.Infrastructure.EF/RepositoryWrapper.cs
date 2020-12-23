using Domain.Infrastructure.EF.Repositories;
using Domain.Repository;
using System.Threading.Tasks;

namespace Domain.Infrastructure.EF
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        private IProductRepository _products;

        public IProductRepository Product
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_repoContext);
                }
                return _products;

            }
        }

        private ITagRepository _tags;
        public ITagRepository Tag
        {
            get
            {
                if (_tags == null)
                {
                    _tags = new TagRepository(_repoContext);
                }
                return _tags;
            }
        }

        private IProductsTagsRepository _productsInTags;

        public IProductsTagsRepository ProductsTags
        {
            get
            {
                if (_productsInTags == null)
                {
                    _productsInTags = new Repositories.ProductsTagsRepository(_repoContext);
                }
                return _productsInTags;
            }
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
