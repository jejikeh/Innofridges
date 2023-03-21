using Innogotchi.Domain;
using MediatR;

namespace Innogotchi.Application.Commands.InnoUserCommands.CreateInnoUser;

public class CreateInnoUserCommand : IRequest<InnoUser>
{
    public string Username { get; set; } = "Default";
    public string Email { get; set; } = "default@noname.com";
    public string PasswordHash { get; set; } = "";
}