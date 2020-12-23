using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class AddTagToProductDto : IValidatableDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid TagId { get; set; }
    }
}
