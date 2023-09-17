using Application.Abstractions;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;

public class DeleteFridgeProductCommandHandler : IRequestHandler<DeleteFridgeProductCommand>
{
    private readonly IFridgeProductRepository _fridgeProductRepository;

    public DeleteFridgeProductCommandHandler(IFridgeProductRepository fridgeProductRepository)
    {
        _fridgeProductRepository = fridgeProductRepository;
    }

    public async Task Handle(DeleteFridgeProductCommand request, CancellationToken cancellationToken)
    {
        var fridgeProduct = await _fridgeProductRepository.GetFridgeProductAsync(request.Id, cancellationToken);
        if (fridgeProduct is null)
        {
            throw new HttpNotFoundException($"FridgeProduct with id {request.Id} not found.");
        }
        
        _fridgeProductRepository.DeleteFridgeProduct(fridgeProduct);
        await _fridgeProductRepository.SaveChangesAsync(cancellationToken);
    }
}