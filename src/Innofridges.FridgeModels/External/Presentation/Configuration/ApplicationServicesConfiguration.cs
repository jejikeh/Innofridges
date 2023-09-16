using Application;
using Application.Abstractions;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.OpenApi.Models;

namespace Presentation.Configuration;

public static class ApplicationServicesConfiguration
{
    public static WebApplication ConfigureApplicationServices(
        this WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        var applicationConfiguration = new CommonApplicationConfiguration();

        builder.Services
            .AddSingleton((ICommonApplicationConfiguration)applicationConfiguration)
            .AddSwagger()
            .InjectApplication()
            .InjectInfrastructure(configuration)
            .AddControllers();

        return builder.Build();
    }
    
    public static async Task<WebApplication> RunApplicationAsync(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var versityUsersDbContext = serviceProvider.GetRequiredService<InnofridgesDbContext>();
            await versityUsersDbContext.Database.EnsureCreatedAsync();
            
            await webApplication.RunAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR:" + ex.Message);
            
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Host terminated unexpectedly");
        }

        return webApplication;
    }

    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
    
    private static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
        });

        return serviceCollection;
    }
}