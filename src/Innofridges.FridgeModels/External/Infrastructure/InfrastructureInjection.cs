using System.Reflection;
using Application.Abstractions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInjection
{
    public static IServiceCollection InjectInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        if (configuration["Db:ConnectionString"] is not null)
        {
            serviceCollection.AddDbContext<InnofridgesDbContext>(configuration["Db:ConnectionString"]);
        }

        serviceCollection.AddScoped<IFridgeModelsRepository, FridgeModelRepository>();
        serviceCollection.AddScoped<IManufactureRepository, ManufactureRepository>();
        
        return serviceCollection;
    }

    private static IServiceCollection AddDbContext<TDbContext>(
        this IServiceCollection serviceCollection,
        string? connectionString) where TDbContext : DbContext
    {
        serviceCollection.AddDbContext<TDbContext>(options =>
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            options.UseNpgsql(
                connectionString,
                builder =>
                {
                    builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
        });

        return serviceCollection;
    }
}