using System.Reflection;
using AdminPanel.Application.Abstractions;
using AdminPanel.Application.Abstractions.Common;
using Microsoft.Extensions.DependencyInjection;

namespace AdminPanel.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
    }
}