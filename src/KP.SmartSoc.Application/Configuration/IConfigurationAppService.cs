using System.Threading.Tasks;
using KP.SmartSoc.Configuration.Dto;

namespace KP.SmartSoc.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
