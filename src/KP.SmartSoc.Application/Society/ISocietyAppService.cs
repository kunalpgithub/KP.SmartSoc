using Abp.Application.Services;
using Abp.Application.Services.Dto;
using KP.SmartSoc.Society.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP.SmartSoc.Society
{
    public interface ISocietyAppService : IAsyncCrudAppService<SocietyDto, Guid, PagedSocietyResultRequestDto, CreateScoietyDto, SocietyDto>
    {
        //public Task<SocietyDto> GetAsync(EntityDto<Guid> input);
        //public Task CreateAsync(CreateSocietyInput input);
        //public Task<SocietyMember> AddMember(AddSocietyMemberInput input);
        //public Task<ListResultDto<SocietyListDto>> GetListAsync();
        //public Task<IReadOnlyList<SocietyMember>> GetMembersAsync(GetSocietyMemberInput society);
    }
}
