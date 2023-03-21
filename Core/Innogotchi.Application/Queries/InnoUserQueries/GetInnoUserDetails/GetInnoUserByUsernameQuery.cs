using Innogotchi.Domain;
using MediatR;

namespace Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;

public class GetInnoUserByUsernameQuery : IRequest<InnoUser>
{
    public string Username { get; set; }
}