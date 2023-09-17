using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;

public class CreateFridgeProductCommandHandler : IRequestHandler<CreateFridgeProductCommand, FridgeProduct>
{
    private readonly IFridgeProductRepository _fridgeProductRepository;
    private readonly IFridgeRepository _fridgeRepository;
    private readonly IProductRepository _productRepository;

    public CreateFridgeProductCommandHandler(
        IFridgeProductRepository fridgeProductRepository, 
        IFridgeRepository fridgeRepository, 
        IProductRepository productRepository)
    {
        _fridgeProductRepository = fridgeProductRepository;
        _fridgeRepository = fridgeRepository;
        _productRepository = productRepository;
    }

    public async Task<FridgeProduct> Handle(CreateFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridge = await _fridgeRepository.GetFridgeAsync(request.FridgeId, cancellationToken);
        if (fridge is null)
        {
            throw new HttpNotFoundException($"Fridge with id {request.FridgeId} not found.");
        }
        
        var product = await _productRepository.GetProductAsync(request.ProductId, cancellationToken);
        if (product is null)
        {
            throw new HttpNotFoundException($"Product with id {request.ProductId} not found.");
        }

        var fridgeProduct = new FridgeProduct
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            FridgeId = request.FridgeId,
            Quantity = request.Quantity
        };
        
        var fridgeProductCreated = await _fridgeProductRepository.CreateFridgeProductAsync(fridgeProduct, cancellationToken);
        await _fridgeProductRepository.SaveChangesAsync(cancellationToken);
        
        return fridgeProductCreated;
    }
}