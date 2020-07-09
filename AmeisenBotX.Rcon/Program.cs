using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace AmeisenBotX.Rcon
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://0.0.0.0:47111/");
                });

        public static void Main(string[] args)
        {
            Console.Title = "AmeisenBotX RCon Server";
            CreateHostBuilder(args).Build().Run();
        }
    }
}