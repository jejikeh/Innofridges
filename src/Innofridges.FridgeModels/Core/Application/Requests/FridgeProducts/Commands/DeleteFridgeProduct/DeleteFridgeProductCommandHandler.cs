using Application.Abstractions;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;

public class DeleteFridgeProductCommandHandler : IRequestHandler<DeleteFridgeProductCommand>
{
    private readonly IFridgeProductsRepository _fridgeProductsRepository;

    public DeleteFridgeProductCommandHandler(IFridgeProductsRepository fridgeProductsRepository)
    {
        _fridgeProductsRepository = fridgeProductsRepository;
    }

    public async Task Handle(DeleteFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridgeProduct = await _fridgeProductsRepository.GetFridgeProductAsync(request.Id, cancellationToken);
        if (fridgeProduct is null)
        {
            throw new HttpNotFoundException($"FridgeProduct with id {request.Id} not found.");
        }
        
        _fridgeProductsRepository.DeleteFridgeProduct(fridgeProduct);
        await _fridgeProductsRepository.SaveChangesAsync(cancellationToken);
    }
}