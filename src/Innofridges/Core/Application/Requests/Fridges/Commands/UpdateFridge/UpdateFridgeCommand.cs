using Domain;
using MediatR;

namespace Application.Requests.Fridges.Commands.UpdateFridge;

public record UpdateFridgeCommand(
    Guid Id,
    string? OwnerName,
    Guid? ModelId) : IRequest<Fridge>;