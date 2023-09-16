using Domain;
using MediatR;

namespace Application.Requests.Fridges.Queries.GetFridges;

public record GetFridgesCommand(int Page) : IRequest<List<Fridge>>;
