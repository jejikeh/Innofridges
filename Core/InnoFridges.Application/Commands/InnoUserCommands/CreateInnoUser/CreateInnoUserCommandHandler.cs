using AutoMapper;
using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using saja.Commands.CreateUserModel;
using saja.Interfaces;

namespace Innogotchi.Application.Commands.InnoUserCommands.CreateInnoUser;

public class CreateInnoUserCommandHandler : CreateUserModelCommandHandler<CreateInnoUserCommand, InnoUser, IInnoUserRepository>
{
    public CreateInnoUserCommandHandler(IMapper mapper, IInnoUserRepository userModelRepository) : base(mapper, userModelRepository)
    {
    }
}