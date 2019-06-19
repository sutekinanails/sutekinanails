using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace suteservice.api {
    public class Program {
        public static void Main (string[] args) {

            // Creates a logger with the serilog nuget module
            Log.Logger = new LoggerConfiguration ()
                .MinimumLevel.Debug ()
                .MinimumLevel.Override ("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext ()
                .WriteTo.Console ()
                .CreateLogger ();

            try {

                IWebHost host = CreateWebHostBuilder (args).Build ();

                //var logger = host.Services.GetService()
                //logger.LogInformation("Seeded the database.");

                host.Run ();

            } catch (Exception ex) {
                Log.Fatal (ex, "Host terminated unexpectedly.");
            } finally {
                Log.CloseAndFlush ();
            }
        }

        /// <summary>
        /// Creation of the web host, using appsettings.json files and serilog as logger.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <seeref="https://github.com/serilog/serilog-aspnetcore"/>
        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
                .UseSerilog ()
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .ConfigureAppConfiguration ((hostingContext, config) => {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile ("appsettings.json", optional : false, reloadOnChange : true);
                    config.AddJsonFile ($"appsettings.{env.EnvironmentName}.json", optional : true);
                    config.AddEnvironmentVariables ();
                })
                .UseUrls("http://0.0.0.0:8080")
                //.UseUrls("https://0.0.0.0:8080")
                .UseStartup<Startup> ();
    }
}