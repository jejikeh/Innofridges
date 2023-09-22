using Application.Abstractions;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Requests.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductAsync(request.Id, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with id {request.Id} not found.");
        }
        
        _productRepository.DeleteProduct(product);
        await _productRepository.SaveChangesAsync(cancellationToken);
    }
}