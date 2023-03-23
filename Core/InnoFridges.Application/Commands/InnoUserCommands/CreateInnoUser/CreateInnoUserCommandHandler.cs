using AutoMapper;
using InnoFridges.Application.Interfaces;
using InnoFridges.Domain;
using saja.Commands.CreateUserModel;

namespace InnoFridges.Application.Commands.InnoUserCommands.CreateInnoUser;

public class CreateInnoUserCommandHandler : CreateUserModelCommandHandler<CreateInnoUserCommand, InnoUser, IInnoUserRepository>
{
    public CreateInnoUserCommandHandler(IMapper mapper, IInnoUserRepository userModelRepository) : base(mapper, userModelRepository)
    {
    }
}