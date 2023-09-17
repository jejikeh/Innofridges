using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeModels.Commands.UpdateFridgeModel;

public class UpdateFridgeModelCommandHandler : 
    IRequestHandler<UpdateFridgeModelCommand, FridgeModel>
{
    private readonly IFridgeModelsRepository _fridgeModelsRepository;
    private readonly IManufactureRepository _manufactureRepository;

    public UpdateFridgeModelCommandHandler(
        IFridgeModelsRepository fridgeModelsRepository, 
        IManufactureRepository manufactureRepository)
    {
        _fridgeModelsRepository = fridgeModelsRepository;
        _manufactureRepository = manufactureRepository;
    }

    public async Task<FridgeModel> Handle(
        UpdateFridgeModelCommand request, 
        CancellationToken cancellationToken)
    {
        var fridge = await _fridgeModelsRepository.GetFridgeModelAsync(
            request.Id, 
            cancellationToken);

        if (fridge is null)
        {
            throw new HttpNotFoundException($"FridgeModel with ID = {request.Id} was not found");
        }
        
        var manufacture = await _manufactureRepository.GetManufactureAsync(
            request.ManufactureId ?? fridge.ManufactureId, 
            cancellationToken);

        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID={request.ManufactureId} not found");
        }
        
        fridge.ManufactureId = request.ManufactureId ?? fridge.ManufactureId;
        fridge.Name = request.Name ?? fridge.Name;
        fridge.ManufactureDate = request.ManufactureDate ?? fridge.ManufactureDate;
        
        var updateFridgeModel = _fridgeModelsRepository.UpdateFridgeModel(fridge);
        await _fridgeModelsRepository.SaveChangesAsync(cancellationToken);
        
        return updateFridgeModel;
    }
}