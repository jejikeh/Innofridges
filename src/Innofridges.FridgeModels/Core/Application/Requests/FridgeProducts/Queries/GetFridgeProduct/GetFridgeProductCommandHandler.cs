using Application.Abstractions;
using Application.Common.Exceptions;
using Domain;
using MediatR;

namespace Application.Requests.FridgeProducts.Queries.GetFridgeProduct;

public class GetFridgeProductCommandHandler : IRequestHandler<GetFridgeProductCommand, FridgeProduct>
{
    private readonly IFridgeProductRepository _fridgeProductRepository;

    public GetFridgeProductCommandHandler(IFridgeProductRepository fridgeProductRepository)
    {
        _fridgeProductRepository = fridgeProductRepository;
    }

    public async Task<FridgeProduct> Handle(GetFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridgeModule = await _fridgeProductRepository.GetFridgeProductAsync(request.Id,cancellationToken);
        if (fridgeModule is null)
        {
            throw new HttpNotFoundException($"FridgeProduct with id {request.Id} not found.");
        }
        
        return fridgeModule;
    }
}