using Api.Configuration;
using Domain.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IApiInfoConfiguration _apiInfoConfiguration;
        private readonly ILoggingLevelConfiguration _loggingLevelConfiguration;

        public ConfigurationController(
            IOptionsSnapshot<LoggingLevelConfiguration> loglevelConfigurationOptions,
            IOptionsSnapshot<ApiInfoConfiguration> apiInfoConfigurationOptions)
        {
            _loggingLevelConfiguration = loglevelConfigurationOptions.Value;
            _apiInfoConfiguration = apiInfoConfigurationOptions.Value;
        }


        [HttpGet(Name = "get-configurations")]
        public IActionResult Index()
        {
            return Ok(new
            {
                _apiInfoConfiguration.Version,
                _loggingLevelConfiguration.Default
            });
        }
    }
}
