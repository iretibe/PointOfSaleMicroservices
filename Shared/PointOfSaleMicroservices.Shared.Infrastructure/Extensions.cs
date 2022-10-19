using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
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
                .AddSingleton<IClock, UtcClock>()
                //.AddControllers()
                //.ConfigureApplicationPartManager(manager =>
                //{
                //    var removedParts = new List<ApplicationPart>();
                //    foreach (var disabledModule in disabledModules)
                //    {
                //        var parts = manager.ApplicationParts.Where(x => x.Name.Contains(disabledModule,
                //            StringComparison.InvariantCultureIgnoreCase));
                //        removedParts.AddRange(parts);
                //    }

                //    foreach (var part in removedParts)
                //    {
                //        manager.ApplicationParts.Remove(part);
                //    }

                //    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                //});
            ;

            return services;
        }

        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return configuration.GetOptions<T>(sectionName);
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
        {
            var options = new T();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }
    }
}
