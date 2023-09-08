using Domain;
using MediatR;

namespace Application.Requests.FridgeModels.Queries.GetFridgeModels;

public record GetFridgeModelsCommand(int Page) : IRequest<List<FridgeModel>>;