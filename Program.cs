using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
            .UseKestrel()
#if !DEBUG
           .UseContentRoot(@"/webapp/netcoreapp2.2/publish/")
           .UseWebRoot(@"/webapp/netcoreapp2.2/publish/wwwroot")
#endif
           .UseUrls("http://*:5000")
                .UseStartup<Startup>();
    }
}
