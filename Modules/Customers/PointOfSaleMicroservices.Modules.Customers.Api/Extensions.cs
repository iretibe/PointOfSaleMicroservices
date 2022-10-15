using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PointOfSaleMicroservices.Modules.Customers.Core;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PointOfSaleMicroservices.Bootstrapper")]
namespace PointOfSaleMicroservices.Modules.Customers.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddCustomersModule(this IServiceCollection services) 
        {
            services.AddCustomersCore();

            return services;
        }

        public static IApplicationBuilder AddCustomersModule(this IApplicationBuilder app)
        {


            return app;
        }
    }
}
