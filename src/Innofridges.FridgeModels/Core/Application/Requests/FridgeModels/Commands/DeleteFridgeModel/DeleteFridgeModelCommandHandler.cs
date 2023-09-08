using Application.Abstractions;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Requests.FridgeModels.Commands.DeleteFridgeModel;

public class DeleteFridgeModelCommandHandler : IRequestHandler<DeleteFridgeModelCommand>
{
    private readonly IFridgeModelsRepository _fridgeModelsRepository;

    public DeleteFridgeModelCommandHandler(IFridgeModelsRepository fridgeModelsRepository)
    {
        _fridgeModelsRepository = fridgeModelsRepository;
    }

    public async Task Handle(
        DeleteFridgeModelCommand request, 
        CancellationToken cancellationToken)
    {
        var fridge = await _fridgeModelsRepository.GetFridgeModelAsync(
            request.Id, 
            cancellationToken);

        if (fridge is null)
        {
            throw new HttpNotFoundException($"FridgeModel with ID = {request.Id} was not found");
        }

        _fridgeModelsRepository.DeleteFridgeModel(request.Id);
        await _fridgeModelsRepository.SaveChangesAsync(cancellationToken);
    }
}