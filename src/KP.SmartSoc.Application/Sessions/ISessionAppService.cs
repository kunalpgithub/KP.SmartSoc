using System.Threading.Tasks;
using Abp.Application.Services;
using KP.SmartSoc.Sessions.Dto;

namespace KP.SmartSoc.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
