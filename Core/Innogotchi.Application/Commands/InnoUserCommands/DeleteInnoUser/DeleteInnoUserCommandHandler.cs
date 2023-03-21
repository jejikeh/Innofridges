using Innogotchi.Application.Common.Exceptions;
using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using MediatR;

namespace Innogotchi.Application.Commands.InnoUserCommands.DeleteInnoUser;

public class DeleteInnoUserCommandHandler : IRequestHandler<DeleteInnoUserCommand>
{
    private readonly IInnoUserRepository _innoUserRepository;

    public DeleteInnoUserCommandHandler(IInnoUserRepository innoUserRepository)
    {
        _innoUserRepository = innoUserRepository;
    }

    public async Task Handle(DeleteInnoUserCommand request, CancellationToken cancellationToken)
    {
        if (await _innoUserRepository.GetInnoUserById(request.InnoUserId, cancellationToken) is null)
            throw new NotFoundException<InnoUser>(request.InnoUserId);

        await _innoUserRepository.DeleteInnoUser(request.InnoUserId, cancellationToken);
    }
}