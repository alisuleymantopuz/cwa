namespace Api.Models
{
    public class ProductParametersInfo : IValidatableDto
    {
        public ProductParametersInfo()
        {
            OrderBy = "ProductRegisterDate";
            PageNumber = 1;
            PageSize = 100;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
    }
}
