using Application.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class FridgeProductRepository : IFridgeProductRepository
{
    private readonly InnofridgesDbContext _innofridgesDbContext;

    public FridgeProductRepository(InnofridgesDbContext innofridgesDbContext)
    {
        _innofridgesDbContext = innofridgesDbContext;
    }

    public async Task<List<FridgeProduct>> GetFridgeProductsAsync(int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return await _innofridgesDbContext.FridgeProducts
            .AsQueryable()
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<FridgeProduct?> GetFridgeProductAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _innofridgesDbContext
            .FridgeProducts
            .FirstOrDefaultAsync(fridgeProduct => fridgeProduct.Id == id, cancellationToken);
    }

    public async Task<FridgeProduct> CreateFridgeProductAsync(FridgeProduct fridgeProduct, CancellationToken cancellationToken)
    {
        var entityEntry = await _innofridgesDbContext.FridgeProducts.AddAsync(fridgeProduct, cancellationToken);
        return entityEntry.Entity;
    }

    public FridgeProduct UpdateFridgeProduct(FridgeProduct fridgeProduct)
    {
        return _innofridgesDbContext.FridgeProducts.Update(fridgeProduct).Entity;
    }

    public void DeleteFridgeProduct(FridgeProduct fridgeProduct)
    {
        _innofridgesDbContext.FridgeProducts.Remove(fridgeProduct);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _innofridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}