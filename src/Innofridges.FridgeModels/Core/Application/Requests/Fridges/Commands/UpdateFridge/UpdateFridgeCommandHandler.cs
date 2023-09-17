using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.Fridges.Commands.UpdateFridge;

public class UpdateFridgeCommandHandler : IRequestHandler<UpdateFridgeCommand, Fridge>
{
    private readonly IFridgeRepository _fridgeRepository;
    private readonly IFridgeModelsRepository _fridgeModelsRepository;

    public UpdateFridgeCommandHandler(
        IFridgeRepository fridgeRepository, 
        IFridgeModelsRepository fridgeModelsRepository)
    {
        _fridgeRepository = fridgeRepository;
        _fridgeModelsRepository = fridgeModelsRepository;
    }

    public async Task<Fridge> Handle(
        UpdateFridgeCommand request, 
        CancellationToken cancellationToken)
    {
        var fridge = await _fridgeRepository.GetFridgeAsync(request.Id, cancellationToken);
        if (fridge is null)
        {
            throw new HttpNotFoundException($"Fridge with id {request.Id} not found.");
        }
        
        var model = await _fridgeModelsRepository.GetFridgeModelAsync(
            request.ModelId ?? fridge.ModelId, 
            cancellationToken);

        if (model is null)
        {
            throw new HttpNotFoundException($"Model with ID={request.ModelId} not found");
        }
        
        fridge.ModelId = request.ModelId ?? fridge.ModelId;
        fridge.OwnerName = request.OwnerName ?? fridge.OwnerName;
        
        var updateFridge = _fridgeRepository.UpdateFridge(fridge);
        await _fridgeRepository.SaveChangesAsync(cancellationToken);

        return updateFridge;
    }
}