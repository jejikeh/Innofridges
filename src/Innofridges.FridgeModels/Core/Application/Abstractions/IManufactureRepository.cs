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
    public void DeleteManufacture(Guid id);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}