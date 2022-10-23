using InnoGotchi.Application.Interfaces;
using InnoGotchi.Domain;
using InnoGotchi.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.Persistence;
public class PetsDbContext : DbContext, IPetsDbContext
{
    public DbSet<Pet> Pets { get; set; }

    public PetsDbContext(DbContextOptions<PetsDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PetConfiguration());
        base.OnModelCreating(builder);
    }
}