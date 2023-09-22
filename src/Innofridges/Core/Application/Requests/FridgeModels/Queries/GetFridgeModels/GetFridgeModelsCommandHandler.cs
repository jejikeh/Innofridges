using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeModels.Queries.GetFridgeModels;

public class GetFridgeModelsCommandHandler : 
    IRequestHandler<GetFridgeModelsCommand, 
    List<FridgeModel>>
{
    private readonly IFridgeModelsRepository _fridgeModelsRepository;
    private readonly ICommonApplicationConfiguration _applicationConfiguration;

    public GetFridgeModelsCommandHandler(
        IFridgeModelsRepository fridgeModelsRepository, 
        ICommonApplicationConfiguration applicationConfiguration)
    {
        _fridgeModelsRepository = fridgeModelsRepository;
        _applicationConfiguration = applicationConfiguration;
    }

    public async Task<List<FridgeModel>> Handle(
        GetFridgeModelsCommand request, 
        CancellationToken cancellationToken)
    {
        var fridgeModels = await _fridgeModelsRepository.GetFridgeModelsAsync(
            _applicationConfiguration.PageSize * (request.Page - 1),
            _applicationConfiguration.PageSize,
            cancellationToken);
        
        return fridgeModels;
    }
}