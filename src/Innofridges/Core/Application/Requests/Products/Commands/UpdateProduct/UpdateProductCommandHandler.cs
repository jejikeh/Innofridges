using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductAsync(request.Id, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with id {request.Id} not found.");
        }
        
        product.Name = request.Name ?? product.Name;
        product.DefaultQuantity = request.DefaultQuantity ?? product.DefaultQuantity;
        
        var updateProduct = _productRepository.UpdateProduct(product);
        await _productRepository.SaveChangesAsync(cancellationToken);

        return updateProduct;
    }
}