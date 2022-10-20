using Microsoft.Extensions.DependencyInjection;
using PointOfSaleMicroservices.Modules.Customers.Core.DAL;
using PointOfSaleMicroservices.Modules.Customers.Core.DAL.Repositories;
using PointOfSaleMicroservices.Modules.Customers.Core.Domain.Repositories;
using PointOfSaleMicroservices.Shared.Infrastructure.SqlServer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PointOfSaleMicroservices.Modules.Customers.Api")]
namespace PointOfSaleMicroservices.Modules.Customers.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCustomersCore(this IServiceCollection services)
        {
            services
                .AddScoped<ICustomerRepository, CustomersRepository>()
                .AddSqlServers<CustomersDbContext>()
                ;

            return services;
        }
    }
}