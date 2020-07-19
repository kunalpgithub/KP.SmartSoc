using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using KP.SmartSoc.Authorization;

namespace KP.SmartSoc
{
    [DependsOn(
        typeof(SmartSocCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SmartSocApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SmartSocAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SmartSocApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
