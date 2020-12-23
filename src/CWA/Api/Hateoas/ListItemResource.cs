using Newtonsoft.Json;

namespace Api.Hateoas
{
    public class ListItemResource : Resource
    {
        public ListItemResource(object data) : base(data)
        {
        }

        [JsonProperty("items")]
        public override object Data => base.Data;
    }
}
