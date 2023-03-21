using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Innogotchi.WebApi.Infrastructure;

public class AuthOptions
{
    public const string Issuer = "Innogotchi";
    public const string Audience = "InnoUser";
    private const string _key = "TopSecretTokenTopSecretToken1234567890";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
    }
}