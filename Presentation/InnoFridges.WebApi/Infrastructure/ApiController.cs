using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnoFridges.WebApi.Infrastructure;

[ApiController]
[Route("api/[controller]/[action]")]
public class ApiController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator() => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}