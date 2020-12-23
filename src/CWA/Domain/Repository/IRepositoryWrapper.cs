using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        ITagRepository Tag { get; }
        IProductsTagsRepository ProductsTags { get; } 
        Task SaveAsync();
    }
}
