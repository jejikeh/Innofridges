using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using saja.Commands.DeleteUserModel;
using saja.Interfaces;

namespace Innogotchi.Application.Commands.InnoUserCommands.DeleteInnoUser;

public class DeleteInnoUserCommandHandler : DeleteUserModelCommandHandler<InnoUser, IInnoUserRepository>
{
    public DeleteInnoUserCommandHandler(IInnoUserRepository userModelRepository) : base(userModelRepository)
    {
    }
}