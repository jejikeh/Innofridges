namespace InnoFridges.Domain;

public class FridgeProducts
{
    public required Guid FridgeProductsId { get; set; }
    public required Fridge Fridge { get; set; }
    public ICollection<Product> Products { get; set; }
}