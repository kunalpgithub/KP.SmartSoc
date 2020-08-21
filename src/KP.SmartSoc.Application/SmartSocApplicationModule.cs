using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using KP.SmartSoc.Authorization;
using KP.SmartSoc.Society;

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
            //IocManager.Register<ISocietyManager, SocietyManager>(Abp.Dependency.DependencyLifeStyle.Transient);
            //IocManager.Register<ISocietyMemberAddPolicy, SocietyMemberAddPolicy>(Abp.Dependency.DependencyLifeStyle.Transient);
            //IocManager.Register<IRepository<Member>, IRepository<Member>>(Abp.Dependency.DependencyLifeStyle.Transient);

            //IocManager.IocContainer.Register(Classes.FromAssemblyInThisApplication().BasedOn<ISocietyManager>().LifestylePerThread().WithServiceSelf());
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
