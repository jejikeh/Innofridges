using Application.Abstractions;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Requests.Manufactures.Commands.DeleteManufacture;

public class DeleteManufactureCommandHandler : IRequestHandler<DeleteManufactureCommand>
{
    private readonly IManufactureRepository _manufactureRepository;

    public DeleteManufactureCommandHandler(IManufactureRepository manufactureRepository)
    {
        _manufactureRepository = manufactureRepository;
    }

    public async Task Handle(DeleteManufactureCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.GetManufactureAsync(request.Id, cancellationToken);
        if (manufacture is null)
        {
            throw new HttpNotFoundException($"Manufacture with ID=[{request.Id}] not found");
        }
        
        _manufactureRepository.DeleteManufacture(manufacture);
        await _manufactureRepository.SaveChangesAsync(cancellationToken);
    }
}