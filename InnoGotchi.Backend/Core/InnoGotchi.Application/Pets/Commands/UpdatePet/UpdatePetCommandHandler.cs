using InnoGotchi.Application.Common.Exceptions;
using InnoGotchi.Application.Interfaces;
using InnoGotchi.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.Application.Pets.Commands.UpdatePet;
public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand>
{
    private readonly IPetsDbContext _petsDbContext;

    public UpdatePetCommandHandler(IPetsDbContext dbContext)
    {
        _petsDbContext = dbContext;
    }
    
    public async Task<Unit> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await _petsDbContext.Pets.FirstOrDefaultAsync(pet => pet.Id == request.Id || pet.UserId == request.UserId, cancellationToken);
        if (pet is null)
            throw new NotFoundException(nameof(Pet), request.Id);
        
        pet.Name = request.Name;
        await _petsDbContext.SaveChangesAsync(cancellationToken);
        return  Unit.Value;
    }
}