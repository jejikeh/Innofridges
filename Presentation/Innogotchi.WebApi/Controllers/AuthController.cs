using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Innogotchi.Application.Commands.InnoUserCommands.CreateInnoUser;
using Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;
using Innogotchi.Domain;
using Innogotchi.WebApi.Infrastructure;
using Innogotchi.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using saja;

namespace Innogotchi.WebApi.Controllers;

public class AuthController : ApiController
{
    private readonly IMapper _mapper;
    private readonly SajaAuthControllerHandler<InnoUser> _authControllerHandler;

    public AuthController(IMapper mapper)
    {
        _mapper = mapper;
        _authControllerHandler = new SajaAuthControllerHandler<InnoUser>(
            Mediator!, 
            this, 
            new InnogotchiAuthOptions());
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<InnoUserDetailsViewModel>> Account()
    {
        var userId = HttpContext.User.FindFirstValue("UserId");
        var mediator = Mediator();
        if (mediator == null || userId is null) 
            return BadRequest("Internal server error.");
        
        var command = new GetInnoUserDetailsByIdQuery()
        {
            InnoUserId = Guid.Parse(userId)
        };
        
        var innoUserDetailsViewModel = await mediator.Send(command);
        return Ok(innoUserDetailsViewModel);
    }
    
    [HttpPost]
    public async Task<ActionResult<InnoUser>> Register(CreateInnoUserCommand authInnoUserDto)
    {
        return await _authControllerHandler.Register(authInnoUserDto);
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> Login(InnoUserLoginDto innoUserLoginDto)
    {
        var command = new GetInnoUserByUsernameQuery()
        {
            Username = innoUserLoginDto.Username
        };

        return await _authControllerHandler.Login(command, passwordHash =>
            !BCrypt.Net.BCrypt.Verify(innoUserLoginDto.Password, passwordHash));
    }
}