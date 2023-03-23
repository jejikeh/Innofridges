using InnoFridges.Application.Common.Exceptions;
using InnoFridges.Application.Interfaces;
using InnoFridges.Domain;
using MediatR;

namespace InnoFridges.Application.Commands.ProductCommands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;


    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.ProductId, cancellationToken);
        if (product is null)
            throw new NotFoundException<Product>(request.ProductId);
        
        _productRepository.DeleteProduct(product);
        await _productRepository.SaveChangesAsync(cancellationToken);
    }
}