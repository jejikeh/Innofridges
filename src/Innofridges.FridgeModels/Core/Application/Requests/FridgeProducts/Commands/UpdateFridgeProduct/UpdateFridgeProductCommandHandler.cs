using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Commands.UpdateFridgeProduct;

public class UpdateFridgeProductCommandHandler : IRequestHandler<UpdateFridgeProductCommand, FridgeProduct>
{
    private readonly IFridgeProductRepository _fridgeProductRepository;
    private readonly IProductRepository _productRepository;
    private readonly IFridgeRepository _fridgeRepository;

    public UpdateFridgeProductCommandHandler(
        IFridgeProductRepository fridgeProductRepository, 
        IProductRepository productRepository, 
        IFridgeRepository fridgeRepository)
    {
        _fridgeProductRepository = fridgeProductRepository;
        _productRepository = productRepository;
        _fridgeRepository = fridgeRepository;
    }

    public async Task<FridgeProduct> Handle(UpdateFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridgeProduct = await _fridgeProductRepository.GetFridgeProductAsync(request.Id, cancellationToken);
        if (fridgeProduct is null)
        {
            throw new HttpNotFoundException($"FridgeProduct with id {request.Id} not found.");
        }
        
        var product = await _productRepository.GetProductAsync(request.ProductId ?? fridgeProduct.ProductId, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with id {request.ProductId} not found.");
        }
        
        var fridge = await _fridgeRepository.GetFridgeAsync(request.FridgeId ?? fridgeProduct.FridgeId, cancellationToken);
        if (fridge is null)
        {
            throw new HttpNotFoundException($"Fridge with id {request.FridgeId} not found.");
        }
        
        fridgeProduct.ProductId = request.ProductId ?? fridgeProduct.ProductId;
        fridgeProduct.FridgeId = request.FridgeId ?? fridgeProduct.FridgeId;
        fridgeProduct.Quantity = request.Quantity ?? fridgeProduct.Quantity;
        
        var updateFridgeProduct = _fridgeProductRepository.UpdateFridgeProduct(fridgeProduct);
        await _fridgeProductRepository.SaveChangesAsync(cancellationToken);
        
        return updateFridgeProduct;
    }
}