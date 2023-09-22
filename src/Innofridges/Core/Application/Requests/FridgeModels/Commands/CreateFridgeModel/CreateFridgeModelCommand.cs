using Domain;
using MediatR;

namespace Application.Requests.FridgeModels.Commands.CreateFridgeModel;

public record CreateFridgeModelCommand(
    string Name,
    DateOnly ManufactureDate,
    Guid ManufactureId) 
    : IRequest<FridgeModel>;