namespace Domain.Pagination
{
    public class ProductParameters : QueryStringParameters
    {
        public ProductParameters()
        {
            OrderBy = "ProductRegisterDate desc";
        }

        public string Name { get; set; }
    }
}
