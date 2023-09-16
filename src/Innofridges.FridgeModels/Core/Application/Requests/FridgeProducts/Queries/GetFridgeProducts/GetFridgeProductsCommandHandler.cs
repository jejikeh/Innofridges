using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Queries.GetFridgeProducts;

public class GetFridgeProductsCommandHandler : IRequestHandler<GetFridgeProductsCommand, List<FridgeProduct>>
{
    private readonly IFridgeProductsRepository _fridgeProductsRepository;
    private readonly ICommonApplicationConfiguration _applicationConfiguration;

    public GetFridgeProductsCommandHandler(
        IFridgeProductsRepository fridgeProductsRepository, 
        ICommonApplicationConfiguration applicationConfiguration)
    {
        _fridgeProductsRepository = fridgeProductsRepository;
        _applicationConfiguration = applicationConfiguration;
    }

    public async Task<List<FridgeProduct>> Handle(GetFridgeProductsCommand request, CancellationToken cancellationToken)
    {
        var fridgeProducts = await _fridgeProductsRepository.GetFridgeProductsAsync(
            _applicationConfiguration.PageSize * (request.Page - 1),
            _applicationConfiguration.PageSize,
            cancellationToken);
        
        return fridgeProducts;
    }
}