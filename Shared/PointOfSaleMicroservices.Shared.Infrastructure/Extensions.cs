using Microsoft.Extensions.DependencyInjection;
using PointOfSaleMicroservices.Shared.Abstractions.Commands;
using PointOfSaleMicroservices.Shared.Abstractions.Time;
using PointOfSaleMicroservices.Shared.Infrastructure.Commands;
using PointOfSaleMicroservices.Shared.Infrastructure.Time;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PointOfSaleMicroservices.Bootstrapper")]
namespace PointOfSaleMicroservices.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddModularInfrastructure(this IServiceCollection services)
        {
            services
                .AddSingleton<ICommandDispatcher, CommandDispatcher>()
                .AddSingleton<IClock, UtcClock>();

            return services;
        }
    }
}
