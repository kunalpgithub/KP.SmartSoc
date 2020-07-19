using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using KP.SmartSoc.EntityFrameworkCore;
using KP.SmartSoc.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace KP.SmartSoc.Web.Tests
{
    [DependsOn(
        typeof(SmartSocWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SmartSocWebTestModule : AbpModule
    {
        public SmartSocWebTestModule(SmartSocEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SmartSocWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SmartSocWebMvcModule).Assembly);
        }
    }
}