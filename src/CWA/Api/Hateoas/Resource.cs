using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Hateoas
{
    public abstract class Resource
    {
        public Resource(object data)
        {
            this.Data = data;
        }

        [JsonProperty("data")]
        public virtual object Data { get; }

        [JsonProperty("_links", Order = -2)]
        public virtual List<Link> Links { get; } = new List<Link>();
    }
}
