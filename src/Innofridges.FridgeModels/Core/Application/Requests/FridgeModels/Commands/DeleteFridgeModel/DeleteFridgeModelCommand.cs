using MediatR;

namespace Application.Requests.FridgeModels.Commands.DeleteFridgeModel;

public record DeleteFridgeModelCommand(Guid Id) : IRequest;