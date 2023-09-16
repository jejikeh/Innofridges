using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.Fridges.Commands.CreateFridge;

public class CreateFridgeCommandHandler 
    : IRequestHandler<CreateFridgeCommand, Fridge>
{
    private readonly IFridgeModelsRepository _fridgeModelsRepository;
    private readonly IFridgeRepository _fridgeRepository;

    public CreateFridgeCommandHandler(
        IFridgeModelsRepository fridgeModelsRepository, 
        IFridgeRepository fridgeRepository)
    {
        _fridgeModelsRepository = fridgeModelsRepository;
        _fridgeRepository = fridgeRepository;
    }

    public async Task<Fridge> Handle(
        CreateFridgeCommand request, 
        CancellationToken cancellationToken)
    {
        var fridgeModel = await _fridgeModelsRepository.GetFridgeModelAsync(request.ModelId, cancellationToken);
        if (fridgeModel is null)
        {
            throw new HttpNotFoundException($"Fridge model with id {request.ModelId} not found.");
        }

        var fridge = new Fridge
        {
            Id = Guid.NewGuid(),
            OwnerName = request.OwnerName,
            ModelId = request.ModelId
        };
        
        var fridgeCreated = await _fridgeRepository.CreateFridgeAsync(fridge, cancellationToken);
        await _fridgeRepository.SaveChangesAsync(cancellationToken);
        
        return fridgeCreated;
    }
}