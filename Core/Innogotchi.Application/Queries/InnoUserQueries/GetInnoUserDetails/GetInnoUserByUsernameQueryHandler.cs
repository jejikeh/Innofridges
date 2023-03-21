using Innogotchi.Application.Common.Exceptions;
using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using MediatR;

namespace Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;

public class GetInnoUserByUsernameQueryHandler : IRequestHandler<GetInnoUserByUsernameQuery, InnoUser>
{
    private readonly IInnoUserRepository _innoUserRepository;

    public GetInnoUserByUsernameQueryHandler(IInnoUserRepository innoUserRepository)
    {
        _innoUserRepository = innoUserRepository;
    }

    public async Task<InnoUser> Handle(GetInnoUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = await _innoUserRepository.GetInnoUserByUsername(request.Username, cancellationToken);
        if(user is null)
            throw new NotFoundException<InnoUser>(request.Username);

        return user;
    }
}