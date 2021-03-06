using System.Collections.Generic;

namespace Security.JwtSigningCredentials.Interfaces
{
    public interface IJsonWebKeyStore
    {
        void Save(SecurityKeyWithPrivate securityParamteres);
        SecurityKeyWithPrivate GetCurrentKey();
        IReadOnlyCollection<SecurityKeyWithPrivate> Get(int quantity = 5);
        void Clear();
        bool NeedsUpdate();
        void Update(SecurityKeyWithPrivate securityKeyWithPrivate);
    }
}