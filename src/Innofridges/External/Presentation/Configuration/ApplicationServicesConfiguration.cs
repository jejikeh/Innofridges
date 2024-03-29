using Application;
using Application.Abstractions;
using Infrastructure;
using Infrastructure.Common;
using Infrastructure.Persistence;

namespace Presentation.Configuration;

public static class ApplicationServicesConfiguration
{
    public static WebApplication ConfigureApplicationServices(
        this WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        var applicationConfiguration = new CommonApplicationConfiguration(configuration);

        builder.Services
            .AddSingleton((ICommonApplicationConfiguration)applicationConfiguration)
            .AddSwaggerGen()
            .InjectApplication()
            .InjectInfrastructure(applicationConfiguration)
            .AddControllers();

        builder.Services.AddAuthentication();
        
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
}