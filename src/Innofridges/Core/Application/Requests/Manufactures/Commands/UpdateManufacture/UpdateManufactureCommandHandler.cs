using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Commands.UpdateManufacture;

public class UpdateManufactureCommandHandler : IRequestHandler<UpdateManufactureCommand, Manufacture>
{
    private readonly IManufactureRepository _manufactureRepository;

    public UpdateManufactureCommandHandler(IManufactureRepository manufactureRepository)
    {
        _manufactureRepository = manufactureRepository;
    }

    public async Task<Manufacture> Handle(UpdateManufactureCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.GetManufactureAsync(request.Id, cancellationToken);
        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID=[{request.Id}] not found");
        }
        
        manufacture.Name = request.Name ?? manufacture.Name;
        
        var updateManufacture = _manufactureRepository.UpdateManufacture(manufacture);
        await _manufactureRepository.SaveChangesAsync(cancellationToken);

        return updateManufacture;
    }
}