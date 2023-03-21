using MediatR;

namespace Innogotchi.Application.Commands.InnoUserCommands.UpdateInnoUser;

public class UpdateInnoUserCommand : IRequest
{
    public Guid InnoUserId { get; set; }
    public string Username { get; set; } = "Default";
    public string Email { get; set; } = "default@noname.com";
    public string PasswordHash { get; set; } = "";
}