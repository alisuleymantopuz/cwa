using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class ProductDetailDto : IValidatableDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductRegisterDate { get; set; }
        public decimal UnitPrice { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<ProductTagsDto> ProductsTags { get; set; }
    }
}
