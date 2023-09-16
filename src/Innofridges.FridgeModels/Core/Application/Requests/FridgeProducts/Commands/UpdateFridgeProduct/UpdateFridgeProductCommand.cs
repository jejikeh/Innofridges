using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Commands.UpdateFridgeProduct;

public record UpdateFridgeProductCommand(
    Guid Id,
    Guid ProductId, 
    Guid FridgeId, 
    int Quantity) : IRequest<FridgeProduct>;
