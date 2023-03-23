using MediatR;

namespace InnoFridges.Application.Commands.ProductCommands.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public Guid ProductId { get; set; }
}