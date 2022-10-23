using InnoGotchi.Application.Interfaces;
using InnoGotchi.Domain;
using MediatR;

namespace InnoGotchi.Application.Pets.Commands.CreatePet;
public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Guid>
{
    private readonly IPetsDbContext _petsDbContext;

    public CreatePetCommandHandler(IPetsDbContext dbContext)
    {
        _petsDbContext = dbContext;
    }
    
    public async Task<Guid> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = new Pet
        {
            UserId = request.UserId,
            Name = request.Name,
            Id = Guid.NewGuid(),
            BornDate = DateTime.Now
        };

        await _petsDbContext.Pets.AddAsync(pet, cancellationToken);
        await _petsDbContext.SaveChangesAsync(cancellationToken);

        return pet.Id;
    }
}