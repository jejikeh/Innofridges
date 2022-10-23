using InnoGotchi.Domain;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.Application.Interfaces;

public interface IPetsDbContext
{
    DbSet<Pet> Pets { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}