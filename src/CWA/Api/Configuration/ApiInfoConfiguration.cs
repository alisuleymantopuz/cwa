using Domain.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Api.Configuration
{
    public class ApiInfoConfiguration : IApiInfoConfiguration
    {
        [Required(ErrorMessage ="Api version info is required!")]
        public string Version { get; set; }
    }
}
