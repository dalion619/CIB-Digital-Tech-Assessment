using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;

namespace CIBDigitalTechAssessment.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<PhoneBookDbContext>();
                await PhoneBookSeedData.Seed(dbContext);
            }
          
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(configureLogging: (hostingContext, logging) =>
                    {
                        logging
                            .ClearProviders()
                            .AddConsole(configure: options => { options.IncludeScopes = true; })
                            .AddFilter<ConsoleLoggerProvider>(category: "Microsoft", level: LogLevel.None)
                            .AddFilter<ConsoleLoggerProvider>(category: "", level: LogLevel.Information)
                            .AddDebug()
                            .AddFilter<DebugLoggerProvider>(category: "", level: LogLevel.Trace);
                    }
                )
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>().UseIISIntegration(); });
    }
}