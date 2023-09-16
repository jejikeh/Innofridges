using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Queries.GetFridgeProducts;

public record GetFridgeProductsCommand(int Page) : IRequest<List<FridgeProduct>>;