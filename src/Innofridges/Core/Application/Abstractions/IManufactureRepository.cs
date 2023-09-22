using Domain;

namespace Application.Abstractions;

public interface IManufactureRepository
{
    public Task<List<Manufacture>> GetManufacturesAsync(
        int skipCount, 
        int takeCount, 
        CancellationToken cancellationToken);
    
    public Task<Manufacture?> GetManufactureAsync(
        Guid id, 
        CancellationToken cancellationToken);
    
    public Task<Manufacture> CreateManufactureAsync(
        Manufacture manufacture, 
        CancellationToken cancellationToken);
    
    public Manufacture UpdateManufacture(Manufacture manufacture);
    public void DeleteManufacture(Manufacture manufacture);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
    
    public Task<List<FridgeModel>> GetManufactureModelsAsync(
        Guid id, 
        int skipCount, 
        int takeCount,
        CancellationToken cancellationToken);
}