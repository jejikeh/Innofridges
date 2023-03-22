using System.ComponentModel.DataAnnotations;

namespace Innogotchi.WebApi.Models;

public class InnoUserLoginDto
{
    public string Username { get; set; } = "Default";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "default@noname.com";
}