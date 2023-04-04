using AdavancedTopics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared;
using System;

namespace AdvancedTopics
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddCustomServices()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Starting application");


            var samples = serviceProvider.GetServices<ISample>();

            foreach (var sample in samples)
            {
                sample.Run();
            }

            logger.LogDebug("All done!");

            Console.Read();
        }
    }
}
