using AutoMapper;
using InnoFridges.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InnoFridges.Application.Queries.ProductQueries.GetProductsList;

public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListViewModel>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsListQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductsListViewModel> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository
            .GetDbSet()
            .ProjectTo<ProductIdNameDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ProductsListViewModel()
        {
            Products = products
        };
    }
}