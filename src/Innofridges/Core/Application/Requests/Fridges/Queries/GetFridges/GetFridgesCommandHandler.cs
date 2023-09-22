using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Requests.Fridges.Queries.GetFridges;

public class GetFridgesCommandHandler : IRequestHandler<GetFridgesCommand, List<Fridge>>
{
    private readonly IFridgeRepository _fridgeRepository;
    private readonly ICommonApplicationConfiguration _applicationConfiguration;

    public GetFridgesCommandHandler(
        IFridgeRepository fridgeRepository, 
        ICommonApplicationConfiguration applicationConfiguration)
    {
        _fridgeRepository = fridgeRepository;
        _applicationConfiguration = applicationConfiguration;
    }

    public async Task<List<Fridge>> Handle(GetFridgesCommand request, CancellationToken cancellationToken)
    {
        var fridges = await _fridgeRepository.GetFridgesAsync(
            _applicationConfiguration.PageSize * (request.Page - 1),
            _applicationConfiguration.PageSize,
            cancellationToken);
        
        return fridges;
    }
}