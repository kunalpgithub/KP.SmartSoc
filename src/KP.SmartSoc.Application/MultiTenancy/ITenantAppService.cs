using Abp.Application.Services;
using KP.SmartSoc.MultiTenancy.Dto;

namespace KP.SmartSoc.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

