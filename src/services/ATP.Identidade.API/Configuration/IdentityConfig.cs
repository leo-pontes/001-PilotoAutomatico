using ATP.Identidade.API.Data;
using ATP.Identidade.API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.JwtSigningCredentials;

namespace ATP.Identidade.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
           IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppTokenSettings");
            services.Configure<AppTokenSettings>(appSettingsSection);

            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString")));

            services.AddJwksManager(options => options.Algorithm = Algorithm.ES256)
                .PersistKeysToDatabaseStore<IdentityContext>();                      

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
