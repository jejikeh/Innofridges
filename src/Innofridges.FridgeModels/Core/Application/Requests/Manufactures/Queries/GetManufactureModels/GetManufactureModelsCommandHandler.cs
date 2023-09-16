using Application.Abstractions;
using Application.Common.Dto;
using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Queries.GetManufactureModels;

public class GetManufactureModelsCommandHandler : IRequestHandler<GetManufactureModelsCommands, List<ManufactureFridgeModelDto>>
{
    private readonly IManufactureRepository _manufactureRepository;
    private readonly ICommonApplicationConfiguration _applicationConfiguration;

    public GetManufactureModelsCommandHandler(IManufactureRepository manufactureRepository, ICommonApplicationConfiguration applicationConfiguration)
    {
        _manufactureRepository = manufactureRepository;
        _applicationConfiguration = applicationConfiguration;
    }

    public async Task<List<ManufactureFridgeModelDto>> Handle(GetManufactureModelsCommands request, CancellationToken cancellationToken)
    {
        var fridge = await _manufactureRepository.GetManufactureModelsAsync(
            request.Id, 
            _applicationConfiguration.PageSize * (request.Page - 1), 
            _applicationConfiguration.PageSize, 
            cancellationToken);
        
        return fridge.Select(ManufactureFridgeModelDto.FromManufactureModel).ToList();
    }
}