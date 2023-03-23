using AutoMapper;
using InnoFridges.Application.Interfaces;
using MediatR;

namespace InnoFridges.Application.Queries.ProductQueries.GetProductDetails;

public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsViewModel>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductDetailsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDetailsViewModel> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.ProductId, cancellationToken);
        return _mapper.Map<ProductDetailsViewModel>(product);
    }
}