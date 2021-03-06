using Security.JwtSigningCredentials.Interfaces;
using Security.JwtSigningCredentials.Store.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Builder extension methods for registering crypto services
    /// </summary>
    public static class EFCoreServiceExtensions
    {
        /// <summary>
        /// Sets the signing credential.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="credential">The credential.</param>
        /// <returns></returns>
        public static IJwksBuilder PersistKeysToDatabaseStore<TContext>(this IJwksBuilder builder) where TContext : DbContext, ISecurityKeyContext
        {
            builder.Services.AddScoped<IJsonWebKeyStore, DatabaseJsonWebKeyStore<TContext>>();

            return builder;
        }
    }
}