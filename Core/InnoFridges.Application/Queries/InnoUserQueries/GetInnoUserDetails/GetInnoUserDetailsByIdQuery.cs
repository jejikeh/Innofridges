using MediatR;

namespace InnoFridges.Application.Queries.InnoUserQueries.GetInnoUserDetails;

public class GetInnoUserDetailsByIdQuery : IRequest<InnoUserDetailsViewModel>
{
    public required Guid InnoUserId { get; set; }
}