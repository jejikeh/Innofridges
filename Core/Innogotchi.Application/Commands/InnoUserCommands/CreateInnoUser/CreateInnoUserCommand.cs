using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Innogotchi.Application.Common.Mappings;
using Innogotchi.Domain;
using saja.Commands.CreateUserModel;

namespace Innogotchi.Application.Commands.InnoUserCommands.CreateInnoUser;

public class CreateInnoUserCommand : CreateUserModelCommand<InnoUser>, IMapWith<InnoUser>
{
    [MinLength(3), MaxLength(15)] [Required] public string Username { get; set; } = "Default";
    [MinLength(4)] [Required] public string Password { get; set; } = "";
    [EmailAddress] public string Email { get; set; } = "default@noname.com";
    
    public override void Mapping(Profile profile)
    {
        profile.CreateMap<CreateInnoUserCommand, InnoUser>()
            .ForMember(
                command => command.UserId,
                expression => Guid.NewGuid())
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