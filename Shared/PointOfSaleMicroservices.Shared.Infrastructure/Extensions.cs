﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointOfSaleMicroservices.Shared.Abstractions.Commands;
using PointOfSaleMicroservices.Shared.Abstractions.Dispatchers;
using PointOfSaleMicroservices.Shared.Abstractions.Storage;
using PointOfSaleMicroservices.Shared.Abstractions.Time;
using PointOfSaleMicroservices.Shared.Infrastructure.Api;
using PointOfSaleMicroservices.Shared.Infrastructure.Auth;
using PointOfSaleMicroservices.Shared.Infrastructure.Commands;
using PointOfSaleMicroservices.Shared.Infrastructure.Dispatchers;
using PointOfSaleMicroservices.Shared.Infrastructure.Queries;
using PointOfSaleMicroservices.Shared.Infrastructure.SqlServer;
using PointOfSaleMicroservices.Shared.Infrastructure.Storage;
using PointOfSaleMicroservices.Shared.Infrastructure.Time;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PointOfSaleMicroservices.Bootstrapper")]
namespace PointOfSaleMicroservices.Shared.Infrastructure
{
    public static class Extensions
    {
        private const string CorrelationIdKey = "correlation-id";

        public static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T : class, IInitializer
            => services.AddTransient<IInitializer, T>();

        public static IServiceCollection AddModularInfrastructure(this IServiceCollection services, IList<Assembly> assemblies)
        {
            var disabledModules = new List<string>();
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                foreach (var (key, value) in configuration.AsEnumerable())
                {
                    if (!key.Contains(":module:enabled"))
                    {
                        continue;
                    }

                    if (!bool.Parse(value))
                    {
                        disabledModules.Add(key.Split(":")[0]);
                    }
                }
            }

            services
                .AddSingleton<IRequestStorage, RequestStorage>()
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
                    var removedParts = new List<ApplicationPart>();

                    foreach (var disabledModule in disabledModules)
                    {
                        var parts = manager.ApplicationParts.Where(x => x.Name.Contains(disabledModule,
                            StringComparison.InvariantCultureIgnoreCase));

                        removedParts.AddRange(parts);
                    }

                    foreach (var part in removedParts)
                    {
                        manager.ApplicationParts.Remove(part);
                    }

                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                })
            ;

            return services;
        }

        public static IApplicationBuilder UseModularInfrastructure(this IApplicationBuilder app)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseCors("cors");
            app.UseCorrelationId();
            //app.UseErrorHandling();
            //app.UseSwagger();
            //app.UseReDoc(reDoc =>
            //{
            //    reDoc.RoutePrefix = "docs";
            //    reDoc.SpecUrl("/swagger/v1/swagger.json");
            //    reDoc.DocumentTitle = "Modular API";
            //});
            app.UseAuth();
            //app.UseContext();
            //app.UseLogging();
            app.UseRouting();
            app.UseAuthorization();

            return app;
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

        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
            => app.Use((ctx, next) =>
            {
                ctx.Items.Add(CorrelationIdKey, Guid.NewGuid());
                return next();
            });

        public static Guid? TryGetCorrelationId(this HttpContext context)
            => context.Items.TryGetValue(CorrelationIdKey, out var id) ? (Guid)id : null;
    }
}
