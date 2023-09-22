using System.Text.Json.Serialization;

namespace Domain;

public class Product
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int DefaultQuantity { get; set; }
    public List<FridgeProduct> FridgeProducts { get; set; } = new List<FridgeProduct>();
}