using Microsoft.Extensions.Configuration;
using System.IO;

namespace ATP.Fipe.Scrapping.Config
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _config;

        public ConfigurationHelper()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public string PaginaUrl => _config.GetSection("PaginaUrl").Value;

        public string FolderPath => Directory.GetCurrentDirectory();

        public string WebDrivers => $"{FolderPath}{_config.GetSection("WebDrivers").Value}";
    }
}
