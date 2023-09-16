using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Queries.GetManufactures;

public class GetManufacturesCommandHandler : IRequestHandler<GetManufacturesCommand, List<Manufacture>>
{
    private readonly IManufactureRepository _manufactureRepository;
    private readonly ICommonApplicationConfiguration _applicationConfiguration;

    public GetManufacturesCommandHandler(
        IManufactureRepository manufactureRepository, 
        ICommonApplicationConfiguration applicationConfiguration)
    {
        _manufactureRepository = manufactureRepository;
        _applicationConfiguration = applicationConfiguration;
    }

    public async Task<List<Manufacture>> Handle(GetManufacturesCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.GetManufacturesAsync(
            _applicationConfiguration.PageSize * (request.Page - 1),
            _applicationConfiguration.PageSize,
            cancellationToken);
        
        return manufacture;
    }
}