using Application.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InnofridgesDbContext _innofridgesDbContext;

    public ProductRepository(InnofridgesDbContext innofridgesDbContext)
    {
        _innofridgesDbContext = innofridgesDbContext;
    }

    public async Task<List<Product>> GetProductAsync(int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return await _innofridgesDbContext.Products
            .AsQueryable()
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetProductAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _innofridgesDbContext
            .Products
            .FirstOrDefaultAsync(product => product.Id == id, cancellationToken);
    }

    public async Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        var entityEntry = await _innofridgesDbContext.Products.AddAsync(product, cancellationToken);
        return entityEntry.Entity;
    }

    public Product UpdateProduct(Product product)
    {
        return _innofridgesDbContext.Products.Update(product).Entity;
    }

    public void DeleteProduct(Product product)
    {
        _innofridgesDbContext.Products.Remove(product);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _innofridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}