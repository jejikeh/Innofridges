using saja.Interfaces;

namespace Innogotchi.Domain;

public class InnoUser : IUserModel
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = "Default";
    public string Email { get; set; } = "default@noname.com";
    public string PasswordHash { get; set; } = "";
}