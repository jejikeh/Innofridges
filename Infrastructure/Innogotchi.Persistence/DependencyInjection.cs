using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using Innogotchi.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using saja.Extensions;
using saja.Interfaces;

namespace Innogotchi.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<InnogotchiDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("InnogotchiDbConnection")));

        serviceCollection.AddScoped<IInnoUserRepository, InnoUserRepository>();
        return serviceCollection;
    }
}