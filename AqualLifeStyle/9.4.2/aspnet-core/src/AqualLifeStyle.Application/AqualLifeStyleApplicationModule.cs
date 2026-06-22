using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AqualLifeStyle.Authorization;

namespace AqualLifeStyle
{
    [DependsOn(
        typeof(AqualLifeStyleCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AqualLifeStyleApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AqualLifeStyleAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AqualLifeStyleApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
