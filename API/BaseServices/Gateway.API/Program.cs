using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using Microsoft.AspNetCore;

namespace Gateway.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>()
                          .ConfigureAppConfiguration((hostingContext, config) =>
                          {
                              config.AddJsonFile("ocelot.json")
                              .AddEnvironmentVariables();
                          })
                          .ConfigureServices(s =>
                          {
                              s.AddOcelot();
                          })
                          .Configure(app =>
                          {
                              app.UseOcelot().Wait();
                          })
                          .ConfigureLogging((hostingContext, logging) =>
                          {
                              //add your logging
                          })
                          .UseIISIntegration()
                          .Build();
        }
    }
}
