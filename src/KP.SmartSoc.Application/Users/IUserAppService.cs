using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using KP.SmartSoc.Roles.Dto;
using KP.SmartSoc.Users.Dto;

namespace KP.SmartSoc.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
