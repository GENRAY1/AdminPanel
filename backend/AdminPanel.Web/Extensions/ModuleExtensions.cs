using System.Reflection;
using AdminPanel.Web.Abstractions;

namespace AdminPanel.Web.Extensions;

public static class ModuleExtensions
{
    public static void RegisterModules(this IEndpointRouteBuilder app)
    {
        IEnumerable<IModule> modules = 
            app.ServiceProvider.GetServices<IModule>();
        
        foreach (var module in modules)
        {
            module.RegisterEndpoints(app);
        }
    }

    public static void AddModules(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(classes => classes.AssignableTo<IModule>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
    }
    
}