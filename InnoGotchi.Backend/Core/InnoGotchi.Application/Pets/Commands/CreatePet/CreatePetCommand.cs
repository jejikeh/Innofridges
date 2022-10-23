using MediatR;

namespace InnoGotchi.Application.Pets.Commands.CreatePet;
public class CreatePetCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
}