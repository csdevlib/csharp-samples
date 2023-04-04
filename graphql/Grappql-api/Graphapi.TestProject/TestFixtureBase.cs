using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;

namespace Graphapi.TestProject
{
    public class TestFixtureBase<TStartup> : WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");

            builder.ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile(configPath);
                config.AddEnvironmentVariables();
                config.Build();
            });
        }

        public HttpClient CreateWebApplicationFactory()
        {
            return new WebApplicationFactory<TStartup>().CreateDefaultClient();
        }
    }
}
