using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Commands.UpdateFridgeProduct;

public class UpdateFridgeProductCommandHandler : IRequestHandler<UpdateFridgeProductCommand, FridgeProduct>
{
    private readonly IFridgeProductsRepository _fridgeProductsRepository;
    private readonly IProductRepository _productRepository;
    private readonly IFridgeRepository _fridgeRepository;

    public UpdateFridgeProductCommandHandler(
        IFridgeProductsRepository fridgeProductsRepository, 
        IProductRepository productRepository, 
        IFridgeRepository fridgeRepository)
    {
        _fridgeProductsRepository = fridgeProductsRepository;
        _productRepository = productRepository;
        _fridgeRepository = fridgeRepository;
    }

    public async Task<FridgeProduct> Handle(UpdateFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridgeProduct = await _fridgeProductsRepository.GetFridgeProductAsync(request.Id, cancellationToken);
        
        
    }
}