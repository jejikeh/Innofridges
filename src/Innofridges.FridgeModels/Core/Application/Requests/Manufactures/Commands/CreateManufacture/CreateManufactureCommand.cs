using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Commands.CreateManufacture;

public record CreateManufactureCommand(string Name) : IRequest<Manufacture>;
