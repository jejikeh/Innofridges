using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Commands.CreateManufacture;

public class CreateManufactureCommandHandler : IRequestHandler<CreateManufactureCommand, Manufacture>
{
    private readonly IManufactureRepository _manufactureRepository;

    public CreateManufactureCommandHandler(IManufactureRepository manufactureRepository)
    {
        _manufactureRepository = manufactureRepository;
    }

    public async Task<Manufacture> Handle(CreateManufactureCommand request, CancellationToken cancellationToken)
    {
        var manufacture = new Manufacture()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
        
        var manufactureCreated = await _manufactureRepository.CreateManufactureAsync(manufacture, cancellationToken);
        await _manufactureRepository.SaveChangesAsync(cancellationToken);
        
        return manufactureCreated;
    }
}