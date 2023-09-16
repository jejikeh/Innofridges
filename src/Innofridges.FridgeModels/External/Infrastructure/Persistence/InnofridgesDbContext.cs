using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class InnofridgesDbContext : DbContext
{
    public DbSet<FridgeModel> FridgeModels { get; set; }
    public DbSet<Manufacture> Manufactures { get; set; }

    public InnofridgesDbContext(DbContextOptions<InnofridgesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}