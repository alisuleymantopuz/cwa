using Domain.Infrastructure.EF.Repositories;
using Domain.Repository;
using Domain.Sorting;
using System.Threading.Tasks;

namespace Domain.Infrastructure.EF
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ISortHelper<Tag> _tagSortHelper;
        private ISortHelper<Product> _productSortHelper;
        public RepositoryWrapper(RepositoryContext repositoryContext, ISortHelper<Tag> tagSortHelper, ISortHelper<Product> productSortHelper)
        {
            _repoContext = repositoryContext;
            _tagSortHelper = tagSortHelper;
            _productSortHelper = productSortHelper;
        }

        private IProductRepository _products;

        public IProductRepository Product
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_repoContext, _productSortHelper);
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
                    _tags = new TagRepository(_repoContext, _tagSortHelper);
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
