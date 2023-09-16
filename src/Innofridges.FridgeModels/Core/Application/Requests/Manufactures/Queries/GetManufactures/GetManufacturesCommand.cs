using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Queries.GetManufactures;

public record GetManufacturesCommand(int Page) : IRequest<List<Manufacture>>;
