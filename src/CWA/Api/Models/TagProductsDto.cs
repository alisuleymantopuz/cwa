namespace Api.Models
{
    public class TagProductsDto : IValidatableDto
    {
        public ProductDto Product { get; set; } 
    }
}
