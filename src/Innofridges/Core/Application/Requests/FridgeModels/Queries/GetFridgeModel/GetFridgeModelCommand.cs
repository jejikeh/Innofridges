using Domain;
using MediatR;

namespace Application.Requests.FridgeModels.Queries.GetFridgeModel;

public record GetFridgeModelCommand(Guid Id) : IRequest<FridgeModel>;