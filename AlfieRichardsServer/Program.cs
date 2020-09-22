using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;

namespace AlfieRichardsServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    string p = "";
                    if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "development", StringComparison.InvariantCultureIgnoreCase))
                    {
                        p = System.Reflection.Assembly.GetEntryAssembly().Location;
                        p = p.Substring(0, p.LastIndexOf(@"\") + 1);

                    }
                    else
                    {
                        p = "/webserver/current";
                    }
                        
                    Console.WriteLine(p);

                    webBuilder.ConfigureKestrel(serverOptions => { });
                    webBuilder.UseContentRoot(p);
                    webBuilder.UseStartup<Startup>();
                });
        }

    }
}