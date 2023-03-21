using AutoMapper;
using Innogotchi.Application.Common.Exceptions;
using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using MediatR;

namespace Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;

public class GetInnoUserDetailsByIdQueryHandler : IRequestHandler<GetInnoUserDetailsByIdQuery, InnoUserDetailsViewModel>
{
    private readonly IInnoUserRepository _innoUserRepository;
    private readonly IMapper _mapper;

    public GetInnoUserDetailsByIdQueryHandler(IInnoUserRepository innoUserRepository, IMapper mapper)
    {
        _innoUserRepository = innoUserRepository;
        _mapper = mapper;
    }

    public async Task<InnoUserDetailsViewModel> Handle(GetInnoUserDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _innoUserRepository.GetInnoUserById(request.InnoUserId, cancellationToken);
        if(user is null)
            throw new NotFoundException<InnoUser>(request.InnoUserId);

        return _mapper.Map<InnoUserDetailsViewModel>(user);
    }
}