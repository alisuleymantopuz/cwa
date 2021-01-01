using System;

namespace Api.Models
{
    public class ProductDto : IValidatableDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductRegisterDate { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsImported { get; set; }
    }

    public class CreateProductDto : IValidatableDto
    {
        public string Name { get; set; }
        public DateTime ProductRegisterDate { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
