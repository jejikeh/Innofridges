using Domain;
using MediatR;

namespace Application.Requests.Products.Queries.GetProducts;

public record GetProductsCommand(int Page) : IRequest<List<Product>>;
    
