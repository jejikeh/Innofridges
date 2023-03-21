using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Innogotchi.Application.Commands.InnoUserCommands.CreateInnoUser;
using Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;
using Innogotchi.Domain;
using Innogotchi.WebApi.Infrastructure;
using Innogotchi.WebApi.Models.InnoUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Innogotchi.WebApi.Controllers;

public class AuthController : ApiController
{
    private readonly IMapper _mapper;

    public AuthController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<InnoUserDetailsViewModel>> Account()
    {
        var userId = HttpContext.User.FindFirstValue("InnoUserId");
        if (Mediator == null || userId is null) 
            return BadRequest("Internal server error.");
        
        var command = new GetInnoUserDetailsByIdQuery()
        {
            InnoUserId = Guid.Parse(userId)
        };

        var innoUserDetailsViewModel = await Mediator.Send(command);
        return Ok(innoUserDetailsViewModel);
    }
    
    [HttpPost]
    public async Task<ActionResult<InnoUser>> Register(AuthInnoUserDto authInnoUserDto)
    {
        var command = _mapper.Map<CreateInnoUserCommand>(authInnoUserDto);

        if (Mediator == null) 
            return BadRequest("Internal server error.");
        
        var innoUserDetailsViewModel = await Mediator.Send(command);
        return Ok(innoUserDetailsViewModel);
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> Login(AuthInnoUserDto authInnoUserDto)
    {
        var command = new GetInnoUserByUsernameQuery()
        {
            Username = authInnoUserDto.Username
        };

        if (Mediator == null) 
            return BadRequest("Internal server error.");
        
        var innoUser = await Mediator.Send(command);
        if (!BCrypt.Net.BCrypt.Verify(authInnoUserDto.Password, innoUser.PasswordHash) || authInnoUserDto.Email != innoUser.Email)
            return BadRequest("Register error!");
        
        return Ok(GenerateToken(innoUser));
    }

    private string GenerateToken(InnoUser innoUser)
    {
        var claims = new List<Claim>()
        {
           new Claim(ClaimTypes.Name, innoUser.Username),
           new Claim(ClaimTypes.Email, innoUser.Email),
           new Claim("InnoUserId", innoUser.InnoUserId.ToString()),
        };
        
        var credentials = new SigningCredentials(
            AuthOptions.GetSymmetricSecurityKey(), 
            SecurityAlgorithms.HmacSha256Signature);
        var token = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}