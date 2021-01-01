using Domain.Import;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Import
{
    public class ProductImporter : IProductImporter
    {
        //TODO: config file
        public const string ImportURL = "https://random-data-api.com/api/commerce/random_commerce?size={0}";
        public async Task<IEnumerable<Product>> RetriveImportedProducts(int productCount)
        {
            var baseUrl = string.Format(ImportURL, productCount);
            var imported = new List<ImportedProduct>();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        imported.AddRange(JsonConvert.DeserializeObject<List<ImportedProduct>>(data));
                    }
                }
            }

            return imported.Select(x => new Product()
            {
                Id = Guid.NewGuid(),
                IsImported = true,
                Name = x.ProductName,
                ProductRegisterDate = DateTime.Now,
                UnitPrice = x.Price
            }).ToList();
        }
    }
}
