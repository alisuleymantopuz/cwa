namespace Api.Models
{
    public class ProductTagsDto : IValidatableDto
    {
        public TagDto Tag { get; set; }
    }
}
