using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class InnofridgesDbContext : DbContext
{
    public DbSet<FridgeModel> FridgeModels { get; set; }
    public DbSet<Manufacture> Manufactures { get; set; }
    public DbSet<Fridge> Fridges { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<FridgeProduct> FridgeProducts { get; set; }

    public InnofridgesDbContext(DbContextOptions<InnofridgesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}