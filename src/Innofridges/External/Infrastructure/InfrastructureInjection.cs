using System.Reflection;
using Application.Abstractions;
using Infrastructure.Common;
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
        ICommonInfrastructureConfiguration configuration)
    {
        switch (configuration.DatabaseConfig.DatabaseProvider)
        {
            case DatabaseProvider.PostgreSQL:
                serviceCollection.InjectNpgsql(configuration.DatabaseConfig.ConnectionString);
                break;
            case DatabaseProvider.SQLite:
                serviceCollection.InjectSqlite(configuration.DatabaseConfig.ConnectionString);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        serviceCollection.AddScoped<IFridgeModelsRepository, FridgeModelRepository>();
        serviceCollection.AddScoped<IManufactureRepository, ManufactureRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IFridgeRepository, FridgeRepository>();
        serviceCollection.AddScoped<IFridgeProductRepository, FridgeProductRepository>();
        
        return serviceCollection;
    }

    private static IServiceCollection InjectNpgsql(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<InnofridgesDbContext>(options =>
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
    
    private static IServiceCollection InjectSqlite(
        this IServiceCollection serviceCollection, 
        string? connectionString)
    {
        return serviceCollection.AddDbContext<InnofridgesDbContext>(options =>
        {
            options.EnableDetailedErrors();
            options.UseSqlite(
                connectionString,
                builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
        });
    }
}