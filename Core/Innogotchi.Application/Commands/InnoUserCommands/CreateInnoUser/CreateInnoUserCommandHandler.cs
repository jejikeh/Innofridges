using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using MediatR;

namespace Innogotchi.Application.Commands.InnoUserCommands.CreateInnoUser;

public class CreateInnoUserCommandHandler : IRequestHandler<CreateInnoUserCommand, InnoUser>
{
    private readonly IInnoUserRepository _innoUserRepository;

    public CreateInnoUserCommandHandler(IInnoUserRepository innoUserRepository)
    {
        _innoUserRepository = innoUserRepository;
    }

    public async Task<InnoUser> Handle(CreateInnoUserCommand request, CancellationToken cancellationToken)
    {
        var innoUser = new InnoUser()
        {
            InnoUserId = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = request.PasswordHash,
            Username = request.Username
        };

        await _innoUserRepository.AddInnoUser(innoUser, cancellationToken);
        return innoUser;
    }
}