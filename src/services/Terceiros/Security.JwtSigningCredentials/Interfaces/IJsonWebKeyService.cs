using Microsoft.IdentityModel.Tokens;

namespace Security.JwtSigningCredentials.Interfaces
{
    public interface IJsonWebKeyService
    {
        JsonWebKey Generate(Algorithm algorithm);
    }
}
