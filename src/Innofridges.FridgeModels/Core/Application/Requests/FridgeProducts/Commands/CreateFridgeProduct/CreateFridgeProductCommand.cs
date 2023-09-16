using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;

public record CreateFridgeProductCommand(
    Guid ProductId, 
    Guid FridgeId, 
    int Quantity) : IRequest<FridgeProduct>;