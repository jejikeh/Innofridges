using Application.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ManufactureRepository : IManufactureRepository
{
    private readonly InnofridgesDbContext _innofridgesDbContext;

    public ManufactureRepository(InnofridgesDbContext innofridgesDbContext)
    {
        _innofridgesDbContext = innofridgesDbContext;
    }

    public async Task<List<Manufacture>> GetManufacturesAsync(int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return _innofridgesDbContext.Manufactures
            .AsQueryable()
            .Skip(skipCount)
            .Take(takeCount)
            .ToList();
    }

    public async Task<Manufacture?> GetManufactureAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _innofridgesDbContext
            .Manufactures
            .FirstOrDefaultAsync(manufacture => manufacture.Id == id, cancellationToken);
    }

    public async Task<Manufacture> CreateManufactureAsync(Manufacture manufacture, CancellationToken cancellationToken)
    {
        await _innofridgesDbContext.Manufactures.AddAsync(manufacture, cancellationToken);
        return manufacture;
    }

    public Manufacture UpdateManufacture(Manufacture manufacture)
    {
        return _innofridgesDbContext.Manufactures.Update(manufacture).Entity;
    }

    public void DeleteManufacture(Manufacture manufacture)
    {
        _innofridgesDbContext.Manufactures.Remove(manufacture);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _innofridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}