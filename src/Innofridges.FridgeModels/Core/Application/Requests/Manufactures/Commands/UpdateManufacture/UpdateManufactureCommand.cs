using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Commands.UpdateManufacture;

public record UpdateManufactureCommand(Guid Id, string? Name) : IRequest<Manufacture>;