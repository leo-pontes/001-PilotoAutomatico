using Security.JwtSigningCredentials.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Security.JwtSigningCredentials
{

    public class SecurityKeyWithPrivate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Parameters { get; set; }
        public string KeyId { get; set; }
        public string Type { get; set; }
        public string Algorithm { get; set; }
        public DateTime CreationDate { get; set; }

        public void SetParameters(SecurityKey key, Algorithm alg)
        {
            Parameters = JsonSerializer.Serialize(key, typeof(JsonWebKey), new JsonSerializerOptions() { IgnoreNullValues = true, });
            Type = alg.Kty();
            KeyId = key.KeyId;
            Algorithm = alg;
            CreationDate = DateTime.Now;
        }

        public JsonWebKey GetSecurityKey()
        {
            return JsonSerializer.Deserialize<JsonWebKey>(Parameters);
        }


        public SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(GetSecurityKey(), Algorithm);
        }

        public void SetParameters()
        {
            var jsonWebKey = GetSecurityKey();
            var publicWebKey = PublicJsonWebKey.FromJwk(jsonWebKey);

            Parameters = JsonSerializer.Serialize(publicWebKey.ToNativeJwk(), new JsonSerializerOptions() { IgnoreNullValues = true });
        }
    }
}