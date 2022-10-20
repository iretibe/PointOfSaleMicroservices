﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointOfSaleMicroservices.Shared.Abstractions.Commands;
using PointOfSaleMicroservices.Shared.Abstractions.Dispatchers;
using PointOfSaleMicroservices.Shared.Abstractions.Time;
using PointOfSaleMicroservices.Shared.Infrastructure.Api;
using PointOfSaleMicroservices.Shared.Infrastructure.Commands;
using PointOfSaleMicroservices.Shared.Infrastructure.Dispatchers;
using PointOfSaleMicroservices.Shared.Infrastructure.Postgres;
using PointOfSaleMicroservices.Shared.Infrastructure.Queries;
using PointOfSaleMicroservices.Shared.Infrastructure.SqlServer;
using PointOfSaleMicroservices.Shared.Infrastructure.Time;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PointOfSaleMicroservices.Bootstrapper")]
namespace PointOfSaleMicroservices.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddModularInfrastructure(this IServiceCollection services, IList<Assembly> assemblies)
        {
            services
                .AddCommands(assemblies)
                .AddQueries(assemblies)
                .AddSingleton<IDispatcher, InMemoryDispatcher>()
                //.AddPostgres()
                .AddSqlServers()
                .AddSingleton<ICommandDispatcher, CommandDispatcher>()
                .AddSingleton<IClock, UtcClock>()
                .AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                })
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

        public static string GetModuleName(this object value)
            => value?.GetType().GetModuleName() ?? string.Empty;

        public static string GetModuleName(this Type type, string namespacePart = "Modules", int splitIndex = 2)
        {
            if (type?.Namespace is null)
            {
                return string.Empty;
            }

            return type.Namespace.Contains(namespacePart)
                ? type.Namespace.Split(".")[splitIndex].ToLowerInvariant()
                : string.Empty;
        }

        //public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        //    => app.Use((ctx, next) =>
        //    {
        //        ctx.Items.Add(CorrelationIdKey, Guid.NewGuid());
        //        return next();
        //    });

        //public static Guid? TryGetCorrelationId(this HttpContext context)
        //    => context.Items.TryGetValue(CorrelationIdKey, out var id) ? (Guid)id : null;
    }
}
