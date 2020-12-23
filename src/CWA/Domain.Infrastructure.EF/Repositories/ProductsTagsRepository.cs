using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Infrastructure.EF.Repositories
{
    public class ProductsTagsRepository : RepositoryBase<ProductsTags>, IProductsTagsRepository
    {
        public ProductsTagsRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {

        }

        public void CreateProductsTags(ProductsTags productsTags)
        {
            Create(productsTags);
        }

        public void DeleteProductsTags(ProductsTags productsTags)
        {
            Delete(productsTags);
        }

        public async Task<IEnumerable<ProductsTags>> GetAllProductsTagsAsync()
        {
            return await FindAll()
                        .Include(x => x.Product)
                        .Include(x => x.Tag)
                        .ToListAsync();
        }

        public async Task<ProductsTags> GetProductsTagsAsync(Guid productId, Guid tagId)
        {
            return await FindByCondition(m => m.ProductId.Equals(productId) && m.TagId == tagId)
                        .FirstOrDefaultAsync();
        }

        public void UpdateProductsTags(ProductsTags productsTags)
        {
            Update(productsTags);
        }
    }
}
