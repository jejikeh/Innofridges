using InnoFridges.Application.Interfaces;
using InnoFridges.Domain;
using saja.Commands.DeleteUserModel;

namespace InnoFridges.Application.Commands.InnoUserCommands.DeleteInnoUser;

public class DeleteInnoUserCommandHandler : DeleteUserModelCommandHandler<InnoUser, IInnoUserRepository>
{
    public DeleteInnoUserCommandHandler(IInnoUserRepository userModelRepository) : base(userModelRepository)
    {
    }
}