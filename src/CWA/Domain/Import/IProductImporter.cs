using System.Collections.Generic; 
using System.Threading.Tasks;

namespace Domain.Import
{
    public interface IProductImporter
    {
        Task<IEnumerable<Product>> RetriveImportedProducts(int productCount);
    }
}
