using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeModels.Commands.CreateFridgeModel;

public class CreateFridgeModelCommandHandler : 
    IRequestHandler<CreateFridgeModelCommand, FridgeModel>
{
    private readonly IFridgeModelsRepository _fridgeModelsRepository;
    private readonly IManufactureRepository _manufactureRepository;

    public CreateFridgeModelCommandHandler(
        IFridgeModelsRepository fridgeModelsRepository, 
        IManufactureRepository manufactureRepository)
    {
        _fridgeModelsRepository = fridgeModelsRepository;
        _manufactureRepository = manufactureRepository;
    }

    public async Task<FridgeModel> Handle(
        CreateFridgeModelCommand request, 
        CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.GetManufactureAsync(
            request.ManufactureId, 
            cancellationToken);

        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID={request.ManufactureId} not found");
        }

        var fridgeModel = new FridgeModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ManufactureDate = request.ManufactureDate,
            ManufactureId = request.ManufactureId,
        };
        
        var fridgeModelCreated = await _fridgeModelsRepository.CreateFridgeModelsAsync(fridgeModel, cancellationToken);
        await _fridgeModelsRepository.SaveChangesAsync(cancellationToken);
        
        return fridgeModelCreated;
    }
}