using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Requests.Products.Commands.CreateProduct;

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
            Id = Guid.NewGuid(),
            Name = request.Name,
            DefaultQuantity = request.DefaultQuantity
        };

        var productCreated = await _productRepository.CreateProductAsync(product, cancellationToken);
        await _productRepository.SaveChangesAsync(cancellationToken);

        return productCreated;
    }
}