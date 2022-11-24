using Microsoft.Extensions.DependencyInjection;
using PointOfSaleMicroservices.Modules.Users.Core.DAL;
using PointOfSaleMicroservices.Modules.Users.Core.DAL.Repositories;
using PointOfSaleMicroservices.Modules.Users.Core.Repositories;
using PointOfSaleMicroservices.Modules.Users.Core.Services;
using PointOfSaleMicroservices.Shared.Infrastructure;
using PointOfSaleMicroservices.Shared.Infrastructure.SqlServer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PointOfSaleMicroservices.Modules.Users.Api")]
namespace PointOfSaleMicroservices.Modules.Users.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            var registrationOptions = services.GetOptions<RegistrationOptions>("users:registration");
            services.AddSingleton(registrationOptions);

            services
                .AddSingleton<IUserRequestStorage, UserRequestStorage>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddSqlServers<UsersDbContext>()
                ;

            return services;
        }
    }
}
