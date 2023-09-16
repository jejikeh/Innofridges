using Application.Requests.Manufactures.Commands.CreateManufacture;
using Application.Requests.Manufactures.Commands.DeleteManufacture;
using Application.Requests.Manufactures.Commands.UpdateManufacture;
using Application.Requests.Manufactures.Queries.GetManufacture;
using Application.Requests.Manufactures.Queries.GetManufactureModels;
using Application.Requests.Manufactures.Queries.GetManufactures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManufactureController : ControllerBase
{
    private readonly ISender _sender;

    public ManufactureController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetManufactures(
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetManufacturesCommand(page);
        var response = await _sender.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetManufacture(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetManufactureCommand(id);
        var response = await _sender.Send(command, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpGet("{id}/{page}")]
    public async Task<IActionResult> GetManufactureModels(
        Guid id,
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetManufactureModelsCommands(id, page);
        var response = await _sender.Send(command, cancellationToken);
        
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateManufacture(
        CreateManufactureCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetManufacture), new { id = response.Id }, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteManufacture(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteManufactureCommand(id);
        await _sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateManufacture(
        UpdateManufactureCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetManufacture), new { id = response.Id }, response);
    }
}