using Domain.Infrastructure.EF.Helpers;
using Domain.Repository;
using Domain.Sorting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Infrastructure.EF.Extensions
{
    public static class EntityFrameworkServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:sqlConnection"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlite(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<ISortHelper<Tag>, SortHelper<Tag>>();
            services.AddScoped<ISortHelper<Product>, SortHelper<Product>>(); 
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
