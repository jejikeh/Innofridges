using InnoFridges.Application.Interfaces;
using InnoFridges.Domain;
using saja.Queries;

namespace InnoFridges.Application.Queries.InnoUserQueries.GetInnoUserDetails;

public class GetInnoUserByUsernameQueryHandler : GetModelByUsernameQueryHandler<GetInnoUserByUsernameQuery, InnoUser, IInnoUserRepository>
{
    public GetInnoUserByUsernameQueryHandler(IInnoUserRepository userModelRepository) : base(userModelRepository)
    {
    }
}