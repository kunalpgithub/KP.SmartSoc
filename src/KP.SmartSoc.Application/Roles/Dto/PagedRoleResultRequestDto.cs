using Abp.Application.Services.Dto;

namespace KP.SmartSoc.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

