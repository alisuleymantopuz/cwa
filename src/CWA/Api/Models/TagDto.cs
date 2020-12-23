using System;

namespace Api.Models
{
    public class TagDto : IValidatableDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}