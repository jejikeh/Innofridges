using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Queries.GetFridgeProducts;

public record GetFridgeProductsCommand(Guid FridgeId, int Page) : IRequest<List<FridgeProduct>>;