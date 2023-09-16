using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.Products.Queries.GetProduct;

public class GetProductCommandHandler : IRequestHandler<GetProductCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductAsync(request.Id, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with id {request.Id} not found.");
        }

        return product;
    }
}