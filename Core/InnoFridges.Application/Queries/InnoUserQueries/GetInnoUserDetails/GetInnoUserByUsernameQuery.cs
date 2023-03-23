using Innogotchi.Domain;
using MediatR;
using saja.Queries;

namespace Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;

public class GetInnoUserByUsernameQuery : GetModelByUsernameQuery<InnoUser>
{
}