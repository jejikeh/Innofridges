using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Queries.GetManufacture;

public record GetManufactureCommand(Guid Id) : IRequest<Manufacture>;
