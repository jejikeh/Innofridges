using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Queries.GetFridgeProduct;

public record GetFridgeProductCommand(Guid Id) : IRequest<FridgeProduct>;