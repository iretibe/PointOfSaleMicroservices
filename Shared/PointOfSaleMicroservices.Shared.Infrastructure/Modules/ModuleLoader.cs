﻿using Microsoft.Extensions.Configuration;
using PointOfSaleMicroservices.Shared.Abstractions.Modules;
using System.Reflection;

namespace PointOfSaleMicroservices.Shared.Infrastructure.Modules
{
    public static class ModuleLoader
    {
        public static IList<Assembly> LoadAssemblies(IConfiguration configuration)
        {
            const string ModulePart = "PointOfSaleMicroservices.Modules."; 

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            var locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();

            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
                .ToList();

            var disabledModules = new List<string>();

            foreach (var file in files)
            {
                if(!file.Contains(ModulePart))
                {
                    continue;
                }

                var moduleName = file.Split(ModulePart)[1].Split(".")[0].ToLowerInvariant();

                var enabled = configuration.GetValue<bool>($"{moduleName}:module:enabled");
                
                if (!enabled)
                {
                    disabledModules.Add(file);
                }
            }

            foreach (var disabledModule in disabledModules)
            {
                files.Remove(disabledModule);
            }

            files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

            return assemblies;
        }

        public static IList<IModule> LoadModule(IEnumerable<Assembly> assemblies)
            => assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
            .OrderBy(x => x.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();
    }
}
