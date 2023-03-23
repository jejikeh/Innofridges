using InnoFridges.Application.Common.Exceptions;
using InnoFridges.Application.Interfaces;
using InnoFridges.Domain;
using MediatR;

namespace InnoFridges.Application.Commands.ProductCommands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.ProductId, cancellationToken);
        if (product is null)
            throw new NotFoundException<Product>(request.ProductId);

        var newProduct = new Product()
        {
            Manufacturer = request.Manufacturer,
            Price = request.Price,
            ProductId = request.ProductId,
            ProductName = request.ProductName
        };

        await _productRepository.UpdateProduct(newProduct, cancellationToken);
        await _productRepository.SaveChangesAsync(cancellationToken);
    }
}