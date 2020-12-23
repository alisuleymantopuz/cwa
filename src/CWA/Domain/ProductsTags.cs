using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("ProductsTags")]
    public class ProductsTags
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
