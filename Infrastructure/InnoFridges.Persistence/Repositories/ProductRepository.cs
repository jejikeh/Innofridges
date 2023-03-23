using AutoMapper.QueryableExtensions;
using InnoFridges.Application.Interfaces;
using InnoFridges.Domain;
using Microsoft.EntityFrameworkCore;

namespace InnoFridges.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InnogotchiDbContext _innogotchiDbContext;

    public ProductRepository(InnogotchiDbContext innogotchiDbContext)
    {
        _innogotchiDbContext = innogotchiDbContext;
    }

    public async Task<ICollection<Product>> GetAllProducts(CancellationToken cancellationToken)
    {
        return await _innogotchiDbContext.Products.ToListAsync(cancellationToken);
    }

    public DbSet<Product> GetDbSet()
    {
        return _innogotchiDbContext.Products;
    }

    public async Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        var product = await _innogotchiDbContext.Products.SingleOrDefaultAsync(p => p.ProductId == id, cancellationToken);
        return product;
    }

    public async Task CreateProduct(Product product, CancellationToken cancellationToken)
    {
        await _innogotchiDbContext.Products.AddAsync(product, cancellationToken);
    }

    public async Task UpdateProduct(Product newProduct, CancellationToken cancellationToken)
    {
        var product = await GetProductById(newProduct.ProductId, cancellationToken);
        if (product is null)
            return;

        product = newProduct;
    }

    public void DeleteProduct(Product product)
    {
        _innogotchiDbContext.Remove(product);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _innogotchiDbContext.SaveChangesAsync(cancellationToken);
    }
}