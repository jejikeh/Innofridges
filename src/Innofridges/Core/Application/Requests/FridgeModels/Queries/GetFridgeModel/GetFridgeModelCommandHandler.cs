using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeModels.Queries.GetFridgeModel;

public class GetFridgeModelCommandHandler : 
    IRequestHandler<GetFridgeModelCommand, FridgeModel>
{
    private readonly IFridgeModelsRepository _fridgeModelsRepository;

    public GetFridgeModelCommandHandler(IFridgeModelsRepository fridgeModelsRepository)
    {
        _fridgeModelsRepository = fridgeModelsRepository;
    }

    public async Task<FridgeModel> Handle(
        GetFridgeModelCommand request, 
        CancellationToken cancellationToken)
    {
        var fridge = await _fridgeModelsRepository.GetFridgeModelAsync(
            request.Id,
            cancellationToken);

        if (fridge is null)
        {
            throw new HttpNotFoundException($"FridgeModel ID={request.Id} not found");
        }
        
        return fridge;
    }
}