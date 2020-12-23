using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Services.Extensions
{
    public static class DomainServicesExtensions
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllTagsQueryHandler));
        }
    }
}
