using Api.Configuration;
using Api.Filters;
using Api.Hateoas;
using Api.Middlewares;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("localhost:3000").AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
        public static void ConfigureValidationFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog web app", Version = "v1" });
            });
        }

        public static void ConfigureAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<LoggingLevelConfiguration>().Bind(configuration.GetSection("Logging:LogLevel")).ValidateDataAnnotations();
            services.AddOptions<ApiInfoConfiguration>().Bind(configuration.GetSection("ApiInfo")).ValidateDataAnnotations();
        }

        public static void ConfigureSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog web app V1");
            });
        }

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
        public static void ConfigureHateoas(this IMvcBuilder builder)
        {
            builder.AddHateoas(options =>
            {
                options
                   .AddLink<TagDto>("get-tag-by-id", t => new { id = t.Id })
                   .AddLink<IEnumerable<TagDto>>("get-all-tags")
                   .AddLink<TagDetailsDto>("get-tag-details", t => new { id = t.Id })
                   .AddLink<TagDto>("create-tag")
                   .AddLink<TagDto>("update-tag", t => new { id = t.Id })
                   .AddLink<TagDto>("delete-tag", t => new { id = t.Id });

                options
                   .AddLink<ProductDto>("get-product-by-id", p => new { id = p.Id })
                   .AddLink<IEnumerable<ProductDto>>("get-all-products")
                   .AddLink<ProductDetailDto>("get-product-details", p => new { id = p.Id })
                   .AddLink<ProductDto>("create-product")
                   .AddLink<ProductDto>("update-product", p => new { id = p.Id })
                   .AddLink<ProductDto>("delete-product", p => new { id = p.Id });

                options
                   .AddLink<IEnumerable<CategorizationDto>>("get-categorizations")
                   .AddLink<CategorizationDto>("add-tag-to-product");
            });
        }

        public static IMvcBuilder ConfigureNewtonsoftJson(this IMvcBuilder builder)
        {
            builder.AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            return builder;
        }
    }
}
