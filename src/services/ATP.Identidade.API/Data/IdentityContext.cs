using ATP.Identidade.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Security.JwtSigningCredentials;
using Security.JwtSigningCredentials.Store.EntityFrameworkCore;

namespace ATP.Identidade.API.Data
{
    public class IdentityContext : IdentityDbContext, ISecurityKeyContext
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<SecurityKeyWithPrivate> SecurityKeys { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options): base(options) {}
    }
}
