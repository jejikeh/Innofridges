using MediatR;

namespace Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;

public record DeleteFridgeProductCommand(Guid Id) : IRequest;
