using Domain;
using MediatR;

namespace Application.Requests.Products.Commands.CreateProduct;

public record CreateProductCommand(Guid Id, string Name, int DefaultQuantity) : IRequest<Product>;
