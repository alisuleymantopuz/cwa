using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Infrastructure.EF.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await FindAll()
                        .OrderBy(p => p.Name)
                        .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await FindByCondition(product => product.Id.Equals(productId))
                        .FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductWithDetailsAsync(Guid productId)
        {
            return await FindByCondition(product => product.Id.Equals(productId))
                        .Include(ac => ac.ProductsTags)
                        .ThenInclude(x => x.Tag)
                        .FirstOrDefaultAsync();
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }
    }
}
