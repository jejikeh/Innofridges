using InnoFridges.Domain;
using InnoFridges.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using saja.Interfaces;

namespace InnoFridges.Persistence;

public class InnogotchiDbContext : DbContext, IUserModelDbContext<InnoUser>
{
    public DbSet<InnoUser> Users { get; set; }

    public InnogotchiDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InnoUserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}