using Domain;
using MediatR;

namespace Application.Requests.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, int DefaultQuantity) : IRequest<Product>;
