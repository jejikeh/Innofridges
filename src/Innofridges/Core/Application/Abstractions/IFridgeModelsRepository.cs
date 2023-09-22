using Domain;

namespace Application.Abstractions;

public interface IFridgeModelsRepository
{
    public Task<List<FridgeModel>> GetFridgeModelsAsync(
        int skipCount, 
        int takeCount, 
        CancellationToken cancellationToken);
    
    public Task<FridgeModel?> GetFridgeModelAsync(
        Guid id, 
        CancellationToken cancellationToken);
    
    public Task<FridgeModel> CreateFridgeModelsAsync(
        FridgeModel fridgeModel, 
        CancellationToken cancellationToken);
    
    public FridgeModel UpdateFridgeModel(FridgeModel fridgeModel);
    public void DeleteFridgeModel(FridgeModel fridgeModel);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}