using MediatR;

namespace InnoFridges.Application.Commands.ProductCommands.UpdateProduct;

public class UpdateProductCommand : IRequest
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = "Undefined";
    public string Manufacturer { get; set; } = "Undefined";
    public int Price { get; set; }
}