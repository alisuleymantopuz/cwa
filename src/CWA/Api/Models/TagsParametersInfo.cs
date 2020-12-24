namespace Api.Models
{
    public class TagsParametersInfo : IValidatableDto
    {
        public TagsParametersInfo()
        {
            OrderBy = "Name";
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
    }
}
