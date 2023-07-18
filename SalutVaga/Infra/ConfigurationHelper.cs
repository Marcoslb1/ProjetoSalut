using Microsoft.Extensions.Configuration;
using System.IO;

namespace PRO.Infraestructure
{
    public static class ConfigurationHelper
    {
        public static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
              .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
              .AddJsonFile("appsettings.json")
              .Build();
        }
    }
}
