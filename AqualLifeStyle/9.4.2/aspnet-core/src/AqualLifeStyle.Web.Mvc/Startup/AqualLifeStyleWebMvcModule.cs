using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AqualLifeStyle.Configuration;

namespace AqualLifeStyle.Web.Startup
{
    [DependsOn(typeof(AqualLifeStyleWebCoreModule))]
    public class AqualLifeStyleWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AqualLifeStyleWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<AqualLifeStyleNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AqualLifeStyleWebMvcModule).GetAssembly());
        }
    }
}
