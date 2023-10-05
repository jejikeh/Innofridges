using Application.Abstractions;
using Infrastructure.Common;

namespace Presentation.Configuration;

public class DatabaseConfiguration : ICommonDatabaseConfiguration
{
    public string ConnectionString { get; set; } = string.Empty;
    public DatabaseProvider DatabaseProvider { get; set; }
}

public class CommonApplicationConfiguration : ICommonApplicationConfiguration, ICommonInfrastructureConfiguration
{
    public int PageSize { get; } = 10;
    public RunningEnvironment CurrentEnvironment { get; }
    public ICommonDatabaseConfiguration DatabaseConfig { get; }

    public CommonApplicationConfiguration(IConfiguration configuration)
    {
        CurrentEnvironment = Enum.Parse<RunningEnvironment>(
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development");

        DatabaseConfig = new DatabaseConfiguration()
        {
            ConnectionString = configuration["Database:ConnectionString"] ?? throw new InvalidOperationException("Database connection string is not configured."),
            DatabaseProvider = Enum.Parse<DatabaseProvider>(configuration["Database:DatabaseProvider"] ?? "SQLite")
        };
    }
}