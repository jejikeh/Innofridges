using Application.Abstractions;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Requests.Fridges.Commands.DeleteFridge;

public class DeleteFridgeCommandHandler : IRequestHandler<DeleteFridgeCommand>
{
    private readonly IFridgeRepository _fridgeRepository;

    public DeleteFridgeCommandHandler(IFridgeRepository fridgeRepository)
    {
        _fridgeRepository = fridgeRepository;
    }

    public async Task Handle(DeleteFridgeCommand request, CancellationToken cancellationToken)
    {
        var fridge = await _fridgeRepository.GetFridgeAsync(request.Id, cancellationToken);
        if (fridge is null) 
        {
            throw new HttpNotFoundException($"Fridge with id {request.Id} not found.");
        }
        
        _fridgeRepository.DeleteFridge(fridge);
        await _fridgeRepository.SaveChangesAsync(cancellationToken);
    }
}