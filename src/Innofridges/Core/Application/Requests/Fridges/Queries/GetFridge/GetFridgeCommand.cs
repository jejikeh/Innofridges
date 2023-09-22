using Domain;
using MediatR;

namespace Application.Requests.Fridges.Queries.GetFridge;

public record GetFridgeCommand(Guid Id) : IRequest<Fridge>;
