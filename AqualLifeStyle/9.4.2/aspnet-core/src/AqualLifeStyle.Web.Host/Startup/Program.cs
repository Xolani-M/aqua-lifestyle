using System;
using System.IO;
using Abp.AspNetCore.Dependency;
using Abp.Dependency;
using DotNetEnv;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AqualLifeStyle.Web.Host.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            LoadEnvFile();
            CreateHostBuilder(args).Build().Run();
        }

        private static void LoadEnvFile()
        {
            var directory = Directory.GetCurrentDirectory();
            while (!string.IsNullOrEmpty(directory))
            {
                var envPath = Path.Combine(directory, ".env");
                if (File.Exists(envPath))
                {
                    Console.WriteLine($"[DEBUG] Loading .env from {envPath}");
                    Env.Load(envPath);
                    Console.WriteLine($"[DEBUG] ConnectionStrings__Default={Environment.GetEnvironmentVariable("ConnectionStrings__Default")}");
                    return;
                }

                directory = Directory.GetParent(directory)?.FullName;
            }

            Console.WriteLine("[DEBUG] .env file not found in current or parent directories");
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseCastleWindsor(IocManager.Instance.IocContainer);
    }
}
