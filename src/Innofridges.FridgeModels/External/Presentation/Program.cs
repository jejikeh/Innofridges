using Presentation.Configuration;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.ConfigureApplicationServices(builder.Configuration);

        app.ConfigureApplication();
        
        await app.RunApplicationAsync();
    }
}