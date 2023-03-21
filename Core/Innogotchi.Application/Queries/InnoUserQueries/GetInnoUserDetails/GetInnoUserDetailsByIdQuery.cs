using MediatR;

namespace Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;

public class GetInnoUserDetailsByIdQuery : IRequest<InnoUserDetailsViewModel>
{
    public Guid InnoUserId { get; set; }
}