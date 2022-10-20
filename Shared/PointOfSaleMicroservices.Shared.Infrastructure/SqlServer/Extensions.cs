using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PointOfSaleMicroservices.Shared.Infrastructure.SqlServer
{
    public static class Extensions
    {
        internal static IServiceCollection AddSqlServers(this IServiceCollection services)
        {
            var options = services.GetOptions<SqlServerOptions>("SqlConnectionStrings");
            services.AddSingleton(options);
            services.AddHostedService<DbContextAppInitializer>();

            return services;
        }

        public static IServiceCollection AddSqlServers<T>(this IServiceCollection services) where T : DbContext
        {
            var options = services.GetOptions<SqlServerOptions>("SqlConnectionStrings");

            services.AddDbContext<T>(x => x.UseSqlServer(options.connectionString));

            return services;
        }
    }
}
