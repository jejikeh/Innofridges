using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Queries.GetFridgeProducts;

public class GetFridgeProductsCommandHandler : IRequestHandler<GetFridgeProductsCommand, List<FridgeProduct>>
{
    private readonly IFridgeProductRepository _fridgeProductRepository;
    private readonly ICommonApplicationConfiguration _applicationConfiguration;

    public GetFridgeProductsCommandHandler(
        IFridgeProductRepository fridgeProductRepository, 
        ICommonApplicationConfiguration applicationConfiguration)
    {
        _fridgeProductRepository = fridgeProductRepository;
        _applicationConfiguration = applicationConfiguration;
    }

    public async Task<List<FridgeProduct>> Handle(GetFridgeProductsCommand request, CancellationToken cancellationToken)
    {
        var fridgeProducts = await _fridgeProductRepository.GetFridgeProductsAsync(
            _applicationConfiguration.PageSize * (request.Page - 1),
            _applicationConfiguration.PageSize,
            cancellationToken);
        
        return fridgeProducts;
    }
}