using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using KP.SmartSoc.Configuration.Dto;

namespace KP.SmartSoc.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SmartSocAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
