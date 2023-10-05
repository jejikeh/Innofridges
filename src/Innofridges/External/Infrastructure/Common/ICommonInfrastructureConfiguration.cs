namespace Infrastructure.Common;

public interface ICommonInfrastructureConfiguration
{
    public RunningEnvironment CurrentEnvironment { get; }
    public ICommonDatabaseConfiguration DatabaseConfig { get; }
}

public interface ICommonDatabaseConfiguration
{
    public string ConnectionString { get; set; }
    public DatabaseProvider DatabaseProvider { get; set; }
}