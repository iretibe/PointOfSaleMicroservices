using Microsoft.Extensions.DependencyInjection;
using PointOfSaleMicroservices.Shared.Abstractions.Commands;

namespace PointOfSaleMicroservices.Shared.Infrastructure.Commands
{
    internal static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

            services.Scan(s => s.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
