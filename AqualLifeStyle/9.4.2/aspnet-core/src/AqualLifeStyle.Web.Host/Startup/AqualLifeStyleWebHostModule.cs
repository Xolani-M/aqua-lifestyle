using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AqualLifeStyle.Configuration;

namespace AqualLifeStyle.Web.Host.Startup
{
    [DependsOn(
       typeof(AqualLifeStyleWebCoreModule))]
    public class AqualLifeStyleWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AqualLifeStyleWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AqualLifeStyleWebHostModule).GetAssembly());
        }
    }
}
