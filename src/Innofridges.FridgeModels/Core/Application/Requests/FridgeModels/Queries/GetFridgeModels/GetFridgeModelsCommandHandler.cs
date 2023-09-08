using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeModels.Queries.GetFridgeModels;

public class GetFridgeModelsCommandHandler : 
    IRequestHandler<GetFridgeModelsCommand, 
    List<FridgeModel>>
{
    private readonly IFridgeModelsRepository _fridgeModelsRepository;

    public GetFridgeModelsCommandHandler(IFridgeModelsRepository fridgeModelsRepository)
    {
        _fridgeModelsRepository = fridgeModelsRepository;
    }

    public async Task<List<FridgeModel>> Handle(
        GetFridgeModelsCommand request, 
        CancellationToken cancellationToken)
    {
        var fridgeModels = await _fridgeModelsRepository.GetFridgeModelsAsync(cancellationToken);
    }
}