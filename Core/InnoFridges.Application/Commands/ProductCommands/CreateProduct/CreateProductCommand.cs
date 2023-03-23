using InnoFridges.Domain;
using MediatR;

namespace InnoFridges.Application.Commands.ProductCommands.CreateProduct;

public class CreateProductCommand : IRequest<Product>
{
    public string ProductName { get; set; } = "Undefined";
    public string Manufacturer { get; set; } = "Undefined";
    public int Price { get; set; }
}