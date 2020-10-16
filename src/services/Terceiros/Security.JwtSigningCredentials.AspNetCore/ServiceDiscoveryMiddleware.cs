using System;
using System.Collections.Generic;
using Security.JwtSigningCredentials.Interfaces;
using Security.JwtSigningCredentials.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Security.JwtSigningCredentials.Jwks;

namespace Security.JwtSigningCredentials.AspNetCore
{
    public class ServiceDiscoveryMiddleware
    {
        private readonly RequestDelegate _next;

        public ServiceDiscoveryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IJsonWebKeySetService keyService, IOptions<JwksOptions> options, IMemoryCache memoryCache)
        {
            var keys = new
            {
                keys = keyService.GetLastKeysCredentials(options.Value.AlgorithmsToKeep)?.Select(PublicJsonWebKey.FromJwk)
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(keys, new JsonSerializerOptions() { IgnoreNullValues = true }));
        }
    }
}
