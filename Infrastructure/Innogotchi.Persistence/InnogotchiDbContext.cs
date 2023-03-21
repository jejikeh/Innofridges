using Innogotchi.Domain;
using Innogotchi.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Innogotchi.Persistence;

public class InnogotchiDbContext : DbContext
{
    public DbSet<InnoUser> InnoUsers { get; set; }
    
    public InnogotchiDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InnoUserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}