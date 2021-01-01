using Newtonsoft.Json;

namespace Domain.Infrastructure.Import
{
    public class ImportedProduct
    {
        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
