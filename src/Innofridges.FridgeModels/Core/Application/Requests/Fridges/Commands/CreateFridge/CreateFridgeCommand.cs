using Domain;
using MediatR;

namespace Application.Requests.Fridges.Commands.CreateFridge;

public record CreateFridgeCommand(string OwnerName, Guid ModelId) : IRequest<Fridge>;