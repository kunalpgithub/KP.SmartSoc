using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using KP.SmartSoc.Authorization.Users;
using KP.SmartSoc.Sessions.Dto;
using KP.SmartSoc.Society.Dtos;
using KP.SmartSoc.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP.SmartSoc.Society
{
    public class SocietyAppService : SmartSocAppServiceBase, ISocietyAppService
    {
        private readonly ISocietyManager _societyManager;
        private readonly IRepository<Society, Guid> _societyRepository;

        public SocietyAppService(
            ISocietyManager societyManager,
            IRepository<Society, Guid> societyRepository
            )
        {
            _societyManager = societyManager;
            _societyRepository = societyRepository;
        }
        public async Task<SocietyMember> AddMember(AddSocietyMemberInput addSocietyMemberInput)
        {
            var societyMember = await _societyManager.AddMember(await _societyManager.GetAsync(addSocietyMemberInput.SocietyId), await GetCurrentUserAsync(),addSocietyMemberInput.HouseNo);
            await CurrentUnitOfWork.SaveChangesAsync();
            return societyMember;
        }

        public async Task CreateAsync(CreateSocietyInput input)
        {
            var society = Society.Create(AbpSession.GetTenantId(), input.FullName, input.Address, input.City, input.State, input.Zipcode, input.Country, input.RegistrationNumber);
            await _societyManager.CreateAsync(society);
        }

        public async Task<SocietyDto> GetAsync(EntityDto<Guid> input)
        {
            var society = await _societyRepository.GetAsync(input.Id);

            if (society == null)
            {
                throw new UserFriendlyException("Could not found the society");

            }
            return ObjectMapper.Map<SocietyDto>(society);
        }

        public async Task<ListResultDto<SocietyListDto>> GetListAsync() {
            var societies = await _societyRepository.GetAll().OrderByDescending(e => e.CreationTime).Take(10).ToListAsync();
            return new ListResultDto<SocietyListDto>(ObjectMapper.Map<List<SocietyListDto>>(societies));
        }

        //public Task<IReadOnlyList<UserDto>> GetMembersAsync(GetSocietyMemberInput society)
        //{
        //    throw new NotImplementedException();
        //}
    }

   
}
