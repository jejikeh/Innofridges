using InnoGotchi.Application.Interfaces;
using InnoGotchi.Application.Pets.Commands.UpdatePet;
using MediatR;

namespace InnoGotchi.Application.Pets.Commands.DeletePet;

public class DeletePetCommandHandler : IRequestHandler<UpdatePetCommand>
{
    private readonly IPetsDbContext _petsDbContext;

    public DeletePetCommandHandler(IPetsDbContext dbContext)
    {
        _petsDbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}