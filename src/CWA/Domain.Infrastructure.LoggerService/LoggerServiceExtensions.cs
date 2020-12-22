using Domain.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.IO;

namespace Domain.Infrastructure.LoggerService
{
    public static class LoggerServiceExtensions
    {
        public static void LoadConfiguration()
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
