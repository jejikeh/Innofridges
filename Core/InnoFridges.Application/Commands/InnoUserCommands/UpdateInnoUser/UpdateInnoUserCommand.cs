using AutoMapper;
using InnoFridges.Application.Common.Mappings;
using InnoFridges.Domain;
using saja.Commands.UpdateUserModel;

namespace InnoFridges.Application.Commands.InnoUserCommands.UpdateInnoUser;

public class UpdateInnoUserCommand : UpdateUserModelCommand, IMapWith<InnoUser>
{
    public Guid InnoUserId { get; set; }
    public string Username { get; set; } = "Default";
    public string Email { get; set; } = "default@noname.com";
    public string Password { get; set; } = "";
    
    public override void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateInnoUserCommand, InnoUser>()
            .ForMember(
                command => command.UserId,
                expression => expression.MapFrom(expression => expression.InnoUserId))
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