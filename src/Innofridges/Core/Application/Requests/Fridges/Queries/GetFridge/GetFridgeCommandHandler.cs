using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.Fridges.Queries.GetFridge;

public class GetFridgeCommandHandler : IRequestHandler<GetFridgeCommand, Fridge>
{
    private readonly IFridgeRepository _fridgeRepository;

    public GetFridgeCommandHandler(IFridgeRepository fridgeRepository)
    {
        _fridgeRepository = fridgeRepository;
    }

    public async Task<Fridge> Handle(GetFridgeCommand request, CancellationToken cancellationToken)
    {
        var fridge = await _fridgeRepository.GetFridgeAsync(request.Id, cancellationToken);
        if (fridge is null)
        {
            throw new HttpNotFoundException($"Fridge with id {request.Id} not found.");
        }
        
        return fridge;
    }
}