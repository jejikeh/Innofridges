namespace Domain;

public class Manufacture
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public List<FridgeModel> FridgeModels = new List<FridgeModel>();
}