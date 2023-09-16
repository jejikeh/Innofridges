using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Requests.Products.Queries.GetProducts;

public class GetProductCommandHandler : IRequestHandler<GetProductsCommand, List<Product>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICommonApplicationConfiguration _applicationConfiguration;

    public GetProductCommandHandler(
        IProductRepository productRepository, 
        ICommonApplicationConfiguration applicationConfiguration)
    {
        _productRepository = productRepository;
        _applicationConfiguration = applicationConfiguration;
    }

    public async Task<List<Product>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductAsync(
            _applicationConfiguration.PageSize * (request.Page - 1),
            _applicationConfiguration.PageSize,
            cancellationToken);
        
        return products;
    }
}