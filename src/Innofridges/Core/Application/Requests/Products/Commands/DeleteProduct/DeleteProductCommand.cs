using MediatR;

namespace Application.Requests.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid Id) : IRequest; 