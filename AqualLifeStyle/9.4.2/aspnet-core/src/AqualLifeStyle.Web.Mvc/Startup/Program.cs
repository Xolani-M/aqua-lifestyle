using Abp.AspNetCore.Dependency;
using Abp.Dependency;
using DotNetEnv;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AqualLifeStyle.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load environment variables from a local .env file when present
            Env.Load();
            CreateHostBuilder(args).Build().Run();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseCastleWindsor(IocManager.Instance.IocContainer);
    }
}
