using Microsoft.EntityFrameworkCore;

namespace Security.JwtSigningCredentials.Store.EntityFrameworkCore
{
    public interface ISecurityKeyContext
    {
        /// <summary>
        /// A collection of <see cref="T:.Security.JwtSigningCredentials.SecurityKeyWithPrivate" />
        /// </summary>
        DbSet<SecurityKeyWithPrivate> SecurityKeys { get; set; }
    }
}
