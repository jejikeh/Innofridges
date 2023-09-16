using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Queries.GetFridgeProduct;

public class GetFridgeProductCommandHandler : IRequestHandler<GetFridgeProductCommand, FridgeProduct>
{
    private readonly IFridgeProductsRepository _fridgeProductsRepository;

    public GetFridgeProductCommandHandler(IFridgeProductsRepository fridgeProductsRepository)
    {
        _fridgeProductsRepository = fridgeProductsRepository;
    }

    public async Task<FridgeProduct> Handle(GetFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridgeModule = await _fridgeProductsRepository.GetFridgeProductAsync(request.Id,cancellationToken);
        if (fridgeModule is null)
        {
            throw new HttpNotFoundException($"FridgeProduct with id {request.Id} not found.");
        }
        
        return fridgeModule;
    }
}