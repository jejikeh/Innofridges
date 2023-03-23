using System.Collections;
using InnoFridges.Domain;
using Microsoft.EntityFrameworkCore;

namespace InnoFridges.Application.Interfaces;

public interface IProductRepository
{
    public Task<ICollection<Product>> GetAllProducts(CancellationToken cancellationToken);
    public DbSet<Product> GetDbSet();
    public Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken);
    public Task CreateProduct(Product product, CancellationToken cancellationToken);
    public Task UpdateProduct(Product newProduct, CancellationToken cancellationToken);
    public void DeleteProduct(Product product);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}