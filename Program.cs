using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace ehaikerv202010
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
           /* .UseKestrel()
            .UseIISIntegration()
            .UseWebRoot(AppContext.BaseDirectory + "/wwwroot")
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(LogLevel.Trace);
                    })
#if !DEBUG
           .UseContentRoot(@"/webapp/netcoreapp2.2/publish/")
           .UseWebRoot(@"/webapp/netcoreapp2.2/publish/wwwroot")
#endif
        //.UseUrls("http://*:5000")
                .UseStartup<Startup>();*/
        .UseStartup<Startup>()
                    .ConfigureKestrel((context, options) => { })
                    .UseIISIntegration()
                    // .UseUrls("http://127.0.0.1:5002")
                    .UseWebRoot(AppContext.BaseDirectory + "/wwwroot")
                    .ConfigureLogging(logging =>
                    {
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);
        });
    }
}
