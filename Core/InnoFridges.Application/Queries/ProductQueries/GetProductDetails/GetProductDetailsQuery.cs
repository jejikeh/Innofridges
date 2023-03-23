using MediatR;

namespace InnoFridges.Application.Queries.ProductQueries.GetProductDetails;

public class GetProductDetailsQuery : IRequest<ProductDetailsViewModel>
{
    public Guid ProductId { get; set; }
}