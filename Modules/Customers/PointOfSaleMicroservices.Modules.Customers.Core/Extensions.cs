using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PointOfSaleMicroservices.Modules.Customers.Api")]
namespace PointOfSaleMicroservices.Modules.Customers.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCustomersCore(this IServiceCollection services)
        {
            return services;
        }
    }
}