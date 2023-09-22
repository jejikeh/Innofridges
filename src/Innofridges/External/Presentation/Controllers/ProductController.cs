using Application.Requests.Products.Commands.CreateProduct;
using Application.Requests.Products.Commands.DeleteProduct;
using Application.Requests.Products.Commands.UpdateProduct;
using Application.Requests.Products.Queries.GetProduct;
using Application.Requests.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ISender _sender;

    public ProductController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet("{page:int}")]
    public async Task<IActionResult> GetProducts(
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetProductsCommand(page);
        var response = await _sender.Send(command, cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetProductCommand(id);
        var response = await _sender.Send(command, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);
        await _sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, response);
    }
}