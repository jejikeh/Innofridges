using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Innogotchi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg=> cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return serviceCollection;
    }   
}