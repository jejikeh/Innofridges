using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Innogotchi.WebApi.Infrastructure;

public class InnogotchiAuthOptions : saja.AuthOptions
{
    public override string Issuer { get; } = "Innogotchi";
    public override string Audience { get; } = "InnoUser";
    public override string Key { get; } = "TopSecretTokenTopSecretToken1234567890";
    public static string StaticKey { get; } = "TopSecretTokenTopSecretToken1234567890";
    
    public static SymmetricSecurityKey GetSymmetricSecurityKeyStatic()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticKey));
    }

    public override DateTime Expires { get; set; } = DateTime.Now.AddDays(1);
}