using Api.Extensions;
using Api.Hubs;
using Domain.Infrastructure.EF.Extensions;
using Domain.Infrastructure.Import;
using Domain.Infrastructure.LoggerService;
using Domain.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LoggerServiceExtensions.LoadConfiguration();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.ConfigureDbContext(Configuration);
            services.ConfigureRepositoryWrapper();
            services.ConfigureAutoMapper();
            services.ConfigureValidationFilter();
            services.ConfigureMediatR();
            services.ConfigureAppConfiguration(Configuration);
            services.AddControllers().ConfigureNewtonsoftJson().ConfigureHateoas();
            services.ConfigureSwagger();
            services.AddSignalR();
            services.AddSingleton<MessageHub>();
            services.ConfigureImport();
            services.ConfigureHangfire();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.ConfigureCustomExceptionMiddleware();
            app.ConfigureSwaggerMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(builder =>
              builder.WithOrigins("http://localhost:3000")
                 .AllowAnyHeader().AllowAnyMethod().AllowCredentials()
              );
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
                endpoints.MapHub<MessageHub>("/messageHub");
            });
            app.ConfigureHangfireMiddleware();
        }
    }
}
