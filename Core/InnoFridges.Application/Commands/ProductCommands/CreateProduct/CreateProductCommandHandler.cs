using InnoFridges.Application.Interfaces;
using InnoFridges.Domain;
using MediatR;

namespace InnoFridges.Application.Commands.ProductCommands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Manufacturer = request.Manufacturer,
            Price = request.Price,
            ProductId = Guid.NewGuid(),
            ProductName = request.ProductName
        };
        
        await _productRepository.CreateProduct(product, cancellationToken);
        await _productRepository.SaveChangesAsync(cancellationToken);

        return product;
    }
}