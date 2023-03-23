namespace InnoFridges.Domain;

public class Product
{
    public required Guid ProductId { get; set; }
    public required string ProductName { get; set; }
    public required string Manufacturer { get; set; }
    public int Price { get; set; }
}