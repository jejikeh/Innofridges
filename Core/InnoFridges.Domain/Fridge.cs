namespace InnoFridges.Domain;

public class Fridge
{
    public required Guid FridgeId { get; set; }
    public required FridgeModel Model { get; set; }
    public required InnoUser OwnerUser { get; set; }
}