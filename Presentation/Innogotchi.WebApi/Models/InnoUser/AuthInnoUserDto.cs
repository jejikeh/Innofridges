using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using AutoMapper;
using Innogotchi.Application.Commands.InnoUserCommands.CreateInnoUser;
using Innogotchi.Application.Common.Mappings;
using Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;

namespace Innogotchi.WebApi.Models.InnoUser;

public class AuthInnoUserDto : IMapWith<CreateInnoUserCommand>, IMapWith<GetInnoUserByUsernameQuery>
{
    [Required] public string Username { get; set; } = "Default";
    [Required] public string Password { get; set; } = "";
    public string Email { get; set; } = "default@noname.com";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AuthInnoUserDto, CreateInnoUserCommand>()
            .ForMember(
                command => command.Username,
                expression => expression.MapFrom(expression => expression.Username))
            .ForMember(
                command => command.PasswordHash,
                expression => expression.MapFrom(expression => BCrypt.Net.BCrypt.HashPassword(expression.Password)))
            .ForMember(
                command => command.Email,
                expression => expression.MapFrom(expression => expression.Email));
    }
}