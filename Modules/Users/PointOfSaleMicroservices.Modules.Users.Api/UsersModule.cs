using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PointOfSaleMicroservices.Modules.Users.Core;
using PointOfSaleMicroservices.Modules.Users.Core.DTO;
using PointOfSaleMicroservices.Modules.Users.Core.Queries;
using PointOfSaleMicroservices.Shared.Abstractions.Modules;
using PointOfSaleMicroservices.Shared.Abstractions.Queries;
using PointOfSaleMicroservices.Shared.Infrastructure.Modules;

namespace PointOfSaleMicroservices.Modules.Users.Api
{
    internal class UsersModule : IModule
    {
        public string Name { get; } = "Users";

        public IEnumerable<string> Policies { get; } = new[]
        {
            "users"
        };

        public void Register(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Use(IApplicationBuilder app)
        {
            app.UseModuleRequests()
                .Subscribe<GetUserByEmail, UserDetailsDto>("users/get",
                    (query, serviceProvider, cancellationToken) =>
                        serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken));
        }
    }
}
