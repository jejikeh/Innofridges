using Application.Requests.FridgeModels.Commands.CreateFridgeModel;
using Application.Requests.FridgeModels.Commands.DeleteFridgeModel;
using Application.Requests.FridgeModels.Commands.UpdateFridgeModel;
using Application.Requests.FridgeModels.Queries.GetFridgeModel;
using Application.Requests.FridgeModels.Queries.GetFridgeModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FridgeModelController : ControllerBase
{
    private readonly ISender _sender;

    public FridgeModelController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{page:int}")]
    public async Task<IActionResult> GetFridgeModels(
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgeModelsCommand(page);
        var response = await _sender.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetFridgeModel(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgeModelCommand(id);
        var response = await _sender.Send(command, cancellationToken);
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFridgeModel(
        [FromBody] CreateFridgeModelCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridgeModel), new { id = response.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFridgeModel(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteFridgeModelCommand(id);
        await _sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFridgeModel(
        UpdateFridgeModelCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridgeModel), new { id = response.Id }, response);
    }
}