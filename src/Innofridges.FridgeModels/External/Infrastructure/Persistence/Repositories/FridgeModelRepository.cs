using Application.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class FridgeModelRepository : IFridgeModelsRepository
{
    private readonly InnofridgesDbContext _innofridgesDbContext;

    public FridgeModelRepository(InnofridgesDbContext innofridgesDbContext)
    {
        _innofridgesDbContext = innofridgesDbContext;
    }

    public async Task<List<FridgeModel>> GetFridgeModelsAsync(int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return await _innofridgesDbContext.FridgeModels
            .AsQueryable()
            .OrderBy(data => data.Name)
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<FridgeModel?> GetFridgeModelAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _innofridgesDbContext
            .FridgeModels
            .FirstOrDefaultAsync(model => model.Id == id, cancellationToken);
    }

    public async Task<FridgeModel> CreateFridgeModelsAsync(FridgeModel fridgeModel, CancellationToken cancellationToken)
    {
        await _innofridgesDbContext.FridgeModels.AddAsync(fridgeModel, cancellationToken);
        return fridgeModel;
    }

    public void UpdateFridgeModel(FridgeModel fridgeModel)
    {
        _innofridgesDbContext.FridgeModels.Update(fridgeModel);
    }

    public void DeleteFridgeModel(FridgeModel fridgeModel)
    {
        _innofridgesDbContext.FridgeModels.Remove(fridgeModel);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _innofridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}