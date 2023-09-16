using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Queries.GetManufacture;

public class GetManufactureCommandHandler : IRequestHandler<GetManufactureCommand, Manufacture>
{
    private readonly IManufactureRepository _manufactureRepository;

    public GetManufactureCommandHandler(IManufactureRepository manufactureRepository)
    {
        _manufactureRepository = manufactureRepository;
    }

    public async Task<Manufacture> Handle(GetManufactureCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.GetManufactureAsync(request.Id, cancellationToken);

        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID={request.Id} not found");
        }

        return manufacture;
    }
}