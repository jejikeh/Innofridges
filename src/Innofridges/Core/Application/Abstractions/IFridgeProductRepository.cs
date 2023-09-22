using Domain;

namespace Application.Abstractions;

public interface IFridgeProductRepository
{
    public Task<List<FridgeProduct>> GetFridgeProductsAsync(
        Guid fridgeId,
        int skipCount, 
        int takeCount, 
        CancellationToken cancellationToken);
    
    public Task<FridgeProduct?> GetFridgeProductAsync(
        Guid id, 
        CancellationToken cancellationToken);
    
    public Task<FridgeProduct> CreateFridgeProductAsync(
        FridgeProduct fridgeProduct,
        CancellationToken cancellationToken);
    
    public FridgeProduct UpdateFridgeProduct(FridgeProduct fridgeProduct);
    public void DeleteFridgeProduct(FridgeProduct fridgeProduct);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}