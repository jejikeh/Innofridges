using Innogotchi.Application.Common.Exceptions;
using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using MediatR;

namespace Innogotchi.Application.Commands.InnoUserCommands.UpdateInnoUser;

public class UpdateInnoUserCommandHandler : IRequestHandler<UpdateInnoUserCommand>
{
    private readonly IInnoUserRepository _innoUserRepository;

    public UpdateInnoUserCommandHandler(IInnoUserRepository innoUserRepository)
    {
        _innoUserRepository = innoUserRepository;
    }

    public async Task Handle(UpdateInnoUserCommand request, CancellationToken cancellationToken)
    {
        if (await _innoUserRepository.GetInnoUserById(request.InnoUserId, cancellationToken) is null)
            throw new NotFoundException<InnoUser>(request.InnoUserId);

        var user = new InnoUser()
        {
            InnoUserId = request.InnoUserId,
            Email = request.Email,
            PasswordHash = request.PasswordHash,
            Username = request.Username
        };

        await _innoUserRepository.UpdateInnoUser(user, cancellationToken);
    }
}