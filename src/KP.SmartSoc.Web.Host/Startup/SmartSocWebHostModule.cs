using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using KP.SmartSoc.Configuration;

namespace KP.SmartSoc.Web.Host.Startup
{
    [DependsOn(
       typeof(SmartSocWebCoreModule))]
    public class SmartSocWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SmartSocWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SmartSocWebHostModule).GetAssembly());
        }
    }
}
