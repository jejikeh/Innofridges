using Domain;
using MediatR;

namespace Application.Requests.Products.Queries.GetProduct;

public record GetProductCommand(Guid Id) : IRequest<Product>;
