namespace InnoFridges.Domain;

public class FridgeModel
{
    public required Guid FridgeModelId { get; set; }
    public required string ModelName { get; set; }
    public required string Manufacturer { get; set; }
    public int Year { get; set; }
}