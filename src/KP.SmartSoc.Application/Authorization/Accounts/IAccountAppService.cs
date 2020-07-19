using System.Threading.Tasks;
using Abp.Application.Services;
using KP.SmartSoc.Authorization.Accounts.Dto;

namespace KP.SmartSoc.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
