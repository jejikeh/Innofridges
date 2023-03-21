namespace Innogotchi.Domain;

public class InnoUser
{
    public Guid InnoUserId { get; set; }
    public string Username { get; set; } = "Default";
    public string Email { get; set; } = "default@noname.com";
    public string PasswordHash { get; set; } = "";
}