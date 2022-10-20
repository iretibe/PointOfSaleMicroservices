using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PointOfSaleMicroservices.Modules.Customers.Core;
using PointOfSaleMicroservices.Shared.Abstractions.Modules;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PointOfSaleMicroservices.Bootstrapper")]
namespace PointOfSaleMicroservices.Modules.Customers.Api
{
    internal class CustomersModule : IModule
    {
        public string Name { get; } = "Customers";

        public void Register(IServiceCollection services)
        {
            services.AddCustomersCore();
        }

        public void Use(IApplicationBuilder app)
        {
            
        }
    }
}
