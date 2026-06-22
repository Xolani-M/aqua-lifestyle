using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AqualLifeStyle.Configuration;
using AqualLifeStyle.EntityFrameworkCore;
using AqualLifeStyle.Migrator.DependencyInjection;

namespace AqualLifeStyle.Migrator
{
    [DependsOn(typeof(AqualLifeStyleEntityFrameworkModule))]
    public class AqualLifeStyleMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AqualLifeStyleMigratorModule(AqualLifeStyleEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AqualLifeStyleMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AqualLifeStyleConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AqualLifeStyleMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
