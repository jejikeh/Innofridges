using Domain;
using MediatR;

namespace Application.Requests.FridgeModels.Commands.UpdateFridgeModel;

public record UpdateFridgeModelCommand(
    Guid Id,
    string? Name,
    DateOnly? ManufactureDate,
    Guid? ManufactureId)
    : IRequest<FridgeModel>;