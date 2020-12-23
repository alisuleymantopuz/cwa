using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class TagDetailsDto : IValidatableDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("products")]
        public IEnumerable<TagProductsDto> ProductsTags { get; set; }
    }
}