using Domain;

namespace Application.Abstractions;

public interface IFridgeRepository
{
    public Task<List<Fridge>> GetFridgesAsync(
        int skipCount, 
        int takeCount, 
        CancellationToken cancellationToken);
    
    public Task<Fridge?> GetFridgeAsync(
        Guid id, 
        CancellationToken cancellationToken);
    
    public Task<Fridge> CreateFridgeAsync(
        Fridge fridge, 
        CancellationToken cancellationToken);
    
    public void UpdateFridge(Fridge fridge);
    public void DeleteFridge(Fridge fridge);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}