using System.Text.Json.Serialization;

namespace Domain;

public class FridgeProduct
{
    public required Guid Id { get; set; }
    
    public required Guid ProductId { get; set; }
    [JsonIgnore]
    public Product? Product { get; set; } = null;

    public required Guid FridgeId { get; set; }

    [JsonIgnore]
    public Fridge? Fridge { get; set; } = null;
    
    public required int Quantity { get; set; }
}