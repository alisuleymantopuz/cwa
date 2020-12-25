using Domain.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Api.Configuration
{
    public class LoggingLevelConfiguration : ILoggingLevelConfiguration
    {
        [Required(ErrorMessage = "Default logger is required!")]
        public string Default { get; set; }
    }
}
