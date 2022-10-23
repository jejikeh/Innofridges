using MediatR;

namespace InnoGotchi.Application.Pets.Commands.UpdatePet;

public class UpdatePetCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
}