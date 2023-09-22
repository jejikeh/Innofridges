using Application.Requests.Fridges.Commands.CreateFridge;
using Application.Requests.Fridges.Commands.DeleteFridge;
using Application.Requests.Fridges.Commands.UpdateFridge;
using Application.Requests.Fridges.Queries.GetFridge;
using Application.Requests.Fridges.Queries.GetFridges;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FridgeController : ControllerBase
{
    private readonly ISender _sender;

    public FridgeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{page:int}")]
    public async Task<IActionResult> GetFridges(
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgesCommand(page);
        var response = await _sender.Send(command, cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetFridge(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgeCommand(id);
        var response = await _sender.Send(command, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFridgeModel(
        CreateFridgeCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridge), new { id = response.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFridgeModel(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteFridgeCommand(id);
        await _sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFridgeModel(
        UpdateFridgeCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridge), new { id = response.Id }, response);
    }
}