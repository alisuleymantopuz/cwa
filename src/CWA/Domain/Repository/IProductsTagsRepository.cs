using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IProductsTagsRepository : IRepositoryBase<ProductsTags>
    {
        Task<IEnumerable<ProductsTags>> GetAllProductsTagsAsync();
        Task<ProductsTags> GetProductsTagsAsync(Guid productId, Guid tagId);
        void CreateProductsTags(ProductsTags productsTags);
        void UpdateProductsTags(ProductsTags productsTags);
        void DeleteProductsTags(ProductsTags productsTags);
    }
}
