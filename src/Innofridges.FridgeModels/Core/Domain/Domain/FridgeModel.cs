namespace Domain;

public class FridgeModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly ManufactureDate { get; set; }
    public Guid ManufactureId { get; set; }
    public Manufacture Manufacture { get; set; } = null!;
}