using MediatR;

namespace Application.Requests.Manufactures.Commands.DeleteManufacture;

public record DeleteManufactureCommand(Guid Id) : IRequest;
