using Api.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Hateoas
{
    public static partial class MvcBuilderExtensions
    {
        public static IMvcBuilder AddHateoas(this IMvcBuilder builder, Action<HateoasOptions> options = null)
        {
            if (options != null)
            {
                builder.Services.Configure(options);
            }
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            builder.AddMvcOptions(o => o.OutputFormatters.Add(new JsonHateoasFormatter()));
            return builder;
        }
    }
}
