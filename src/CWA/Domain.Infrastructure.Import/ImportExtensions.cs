using Domain.Import;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Infrastructure.Import
{
    public static class ImportExtensions
    {
        public static void ConfigureImport(this IServiceCollection services)
        {
            services.AddSingleton<IProductImporter, ProductImporter>();
        }
    }
}
