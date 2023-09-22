using Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;
using Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;
using Application.Requests.FridgeProducts.Queries.GetFridgeProduct;
using Application.Requests.FridgeProducts.Queries.GetFridgeProducts;
using Application.Requests.Products.Commands.CreateProduct;
using Application.Requests.Products.Commands.DeleteProduct;
using Application.Requests.Products.Commands.UpdateProduct;
using Application.Requests.Products.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FridgeProductController : ControllerBase
{
    private readonly ISender _sender;

    public FridgeProductController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet("fridge/{fridgeId:guid}/{page:int}")]
    public async Task<IActionResult> GetFridgeProducts(
        Guid fridgeId,
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgeProductsCommand(fridgeId, page);
        var response = await _sender.Send(command, cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetFridgeProduct(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetProductCommand(id);
        var response = await _sender.Send(command, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFridgeProduct(
        CreateFridgeProductCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridgeProduct), new { id = response.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFridgeProduct(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteFridgeProductCommand(id);
        await _sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFridgeProduct(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridgeProducts), new { id = response.Id }, response);
    }
}