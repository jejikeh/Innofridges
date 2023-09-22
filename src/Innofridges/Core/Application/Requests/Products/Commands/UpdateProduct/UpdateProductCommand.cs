using Domain;
using MediatR;

namespace Application.Requests.Products.Commands.UpdateProduct;

public record UpdateProductCommand(Guid Id, string? Name, int? DefaultQuantity) : IRequest<Product>;
