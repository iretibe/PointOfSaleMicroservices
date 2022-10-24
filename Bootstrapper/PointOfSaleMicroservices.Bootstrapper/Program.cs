using PointOfSaleMicroservices.Shared.Infrastructure.Modules;

namespace PointOfSaleMicroservices.Bootstrapper
{
    public class Program
    {
        public static Task Main(string[] args)
            => CreateHostBuilder(args).Build().RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                 .ConfigureModules();
                 //.UseLogging();
    }
}







//using PointOfSaleMicroservices.Shared.Abstractions.Modules;
//using PointOfSaleMicroservices.Shared.Infrastructure;
//using PointOfSaleMicroservices.Shared.Infrastructure.Modules;
//using System.Reflection;

//var builder = WebApplication.CreateBuilder(args);

////IList<Assembly> _assemblies = ;
//var _assemblies = new List<Assembly>();
//var _modules = new List<IModule>();

//_assemblies = (List<Assembly>)ModuleLoader.LoadAssemblies(builder.Configuration);
//_modules = (List<IModule>)ModuleLoader.LoadModule(_assemblies);

//// Add services to the container.
//builder.Services.AddModularInfrastructure(_assemblies);

//foreach (var module in _modules)
//{
//    var services = new ServiceCollection();   
//    //IServiceCollection services = null;
//    module.Register(services);
//}

//var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

//app.UseHttpsRedirection();

//app.UseRouting();

////app.UseCustomersModule();

//foreach (var module in _modules)
//{
//    module.Use(app);
//}

////app.UseAuthorization();

////app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapGet("/", context => context.Response.WriteAsync("Point Of Sale Microservices Bootstrapper"));
//});

//_assemblies.Clear();
//_modules.Clear();

//app.Run();
