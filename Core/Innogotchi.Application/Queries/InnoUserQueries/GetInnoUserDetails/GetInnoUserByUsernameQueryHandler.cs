using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using saja.Queries;

namespace Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;

public class GetInnoUserByUsernameQueryHandler : GetModelByUsernameQueryHandler<GetInnoUserByUsernameQuery, InnoUser, IInnoUserRepository>
{
    public GetInnoUserByUsernameQueryHandler(IInnoUserRepository userModelRepository) : base(userModelRepository)
    {
    }
}