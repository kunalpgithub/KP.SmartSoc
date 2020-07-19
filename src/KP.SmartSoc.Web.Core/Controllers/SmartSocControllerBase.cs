using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace KP.SmartSoc.Controllers
{
    public abstract class SmartSocControllerBase: AbpController
    {
        protected SmartSocControllerBase()
        {
            LocalizationSourceName = SmartSocConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
