namespace InnoFridges.Application.Queries.ProductQueries.GetProductsList;

public class ProductsListViewModel
{
    public required ICollection<ProductIdNameDto> Products { get; set; }
}