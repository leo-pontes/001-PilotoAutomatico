using System;

namespace Security.JwtSigningCredentials
{
    public class JwksOptions
    {
        public Algorithm Algorithm { get; set; } = Algorithm.ES256;
        public int DaysUntilExpire { get; set; } = 90;
        public string KeyPrefix { get; set; } = $"{Environment.MachineName}_";
        public int AlgorithmsToKeep { get; set; } = 2;
        public TimeSpan CacheTime { get; set; } = TimeSpan.FromMinutes(15);
    }
}