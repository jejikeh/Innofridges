using MediatR;

namespace Innogotchi.Application.Commands.InnoUserCommands.DeleteInnoUser;

public class DeleteInnoUserCommand : IRequest
{
    public Guid InnoUserId { get; set; }
}