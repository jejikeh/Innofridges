using AutoMapper;
using InnoFridges.Application.Interfaces;
using InnoFridges.Domain;
using saja.Commands.UpdateUserModel;

namespace InnoFridges.Application.Commands.InnoUserCommands.UpdateInnoUser;

public class UpdateInnoUserCommandHandler : UpdateUserModelCommandHandler<UpdateUserModelCommand, InnoUser, IInnoUserRepository>
{
    public UpdateInnoUserCommandHandler(IInnoUserRepository userModelRepository, IMapper mapper) : base(userModelRepository, mapper)
    {
    }
}