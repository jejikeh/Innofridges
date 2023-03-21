using AutoMapper;
using Innogotchi.Application.Common.Mappings;
using Innogotchi.Domain;

namespace Innogotchi.Application.Queries.InnoUserQueries.GetInnoUserDetails;

public class InnoUserDetailsViewModel : IMapWith<InnoUser>
{
    public Guid InnoUserId { get; set; }
    public string Username { get; set; } = "Default";
    public string Email { get; set; } = "default@noname.com";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<InnoUser, InnoUserDetailsViewModel>()
            .ForMember(
                model => model.InnoUserId, 
                member => member.MapFrom(user => user.InnoUserId))
            .ForMember(
                model => model.Email, 
                member => member.MapFrom(user => user.Email))
            .ForMember(
                model => model.Username, 
                member => member.MapFrom(user => user.Username));
    }
}