using Domain;

namespace Application.Abstractions;

public interface IFridgeProductsRepository
{
    public Task<List<FridgeProduct>> GetFridgeProductsAsync(
        int skipCount, 
        int takeCount, 
        CancellationToken cancellationToken);
    
    public Task<FridgeProduct?> GetFridgeProductAsync(
        Guid id, 
        CancellationToken cancellationToken);
    
    public Task<FridgeProduct> CreateFridgeProductAsync(
        FridgeProduct fridgeProduct,
        CancellationToken cancellationToken);
    
    public void UpdateFridgeProduct(FridgeProduct fridgeProduct);
    public void DeleteFridgeProduct(FridgeProduct fridgeProduct);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}