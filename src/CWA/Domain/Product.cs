using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            ProductsTags = new List<ProductsTags>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product register date is required")]
        public DateTime ProductRegisterDate { get; set; }

        [Required(ErrorMessage = "Unit price is required")]
        public decimal UnitPrice { get; set; }

        public ICollection<ProductsTags> ProductsTags { get; set; }

    }
}
