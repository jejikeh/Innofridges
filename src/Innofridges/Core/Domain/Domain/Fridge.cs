using System.Text.Json.Serialization;

namespace Domain;

public class Fridge
{
    public required Guid Id { get; set; }
    public required string OwnerName { get; set; }
    public required Guid ModelId { get; set; }
    public FridgeModel? Model { get; set; } = null!;
    public List<FridgeProduct> FridgeProducts { get; set; } = new List<FridgeProduct>();
}