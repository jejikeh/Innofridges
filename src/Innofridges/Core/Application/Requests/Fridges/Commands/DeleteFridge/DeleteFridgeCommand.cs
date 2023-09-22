using MediatR;

namespace Application.Requests.Fridges.Commands.DeleteFridge;

public record DeleteFridgeCommand(Guid Id) : IRequest;