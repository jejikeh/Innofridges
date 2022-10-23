using MediatR;

namespace InnoGotchi.Application.Pets.Commands.DeletePet;

public class DeletePetCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}