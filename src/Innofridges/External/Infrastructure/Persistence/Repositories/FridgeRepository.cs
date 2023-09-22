using Application.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class FridgeRepository : IFridgeRepository
{
    private readonly InnofridgesDbContext _innofridgesDbContext;

    public FridgeRepository(InnofridgesDbContext innofridgesDbContext)
    {
        _innofridgesDbContext = innofridgesDbContext;
    }

    public async Task<List<Fridge>> GetFridgesAsync(int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return await _innofridgesDbContext.Fridges
            .AsQueryable()
            .Include(fridge => fridge.FridgeProducts)
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<Fridge?> GetFridgeAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _innofridgesDbContext
            .Fridges
            .FirstOrDefaultAsync(fridge => fridge.Id == id, cancellationToken);
    }

    public async Task<Fridge> CreateFridgeAsync(Fridge fridge, CancellationToken cancellationToken)
    {
        var entityEntry = await _innofridgesDbContext.Fridges.AddAsync(fridge, cancellationToken);
        return entityEntry.Entity;
    }

    public Fridge UpdateFridge(Fridge fridge)
    {
        return _innofridgesDbContext.Fridges.Update(fridge).Entity;
    }

    public void DeleteFridge(Fridge fridge)
    {
        _innofridgesDbContext.Fridges.Remove(fridge);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _innofridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}