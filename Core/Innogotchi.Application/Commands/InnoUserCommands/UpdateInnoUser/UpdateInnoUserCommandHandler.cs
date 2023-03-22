using AutoMapper;
using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using saja.Commands.UpdateUserModel;
using saja.Interfaces;

namespace Innogotchi.Application.Commands.InnoUserCommands.UpdateInnoUser;

public class UpdateInnoUserCommandHandler : UpdateUserModelCommandHandler<UpdateUserModelCommand, InnoUser, IInnoUserRepository>
{
    public UpdateInnoUserCommandHandler(IInnoUserRepository userModelRepository, IMapper mapper) : base(userModelRepository, mapper)
    {
    }
}