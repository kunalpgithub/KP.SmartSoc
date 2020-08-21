//using Abp.Domain.Repositories;
//using Abp.Events.Bus;
//using Abp.UI;
//using KP.SmartSoc.Authorization.Users;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Dynamic.Core;
//using System.Text;
//using System.Threading.Tasks;

//namespace KP.SmartSoc.Society
//{
//    public class SocietyManager : ISocietyManager
//    {
//        public IEventBus EventBus { get; set; }

//        private readonly ISocietyMemberAddPolicy _societyMemberAddPolicy;
//        private readonly IRepository<Member> _societyMemberRepository;
//        private readonly IRepository<Society, Guid> _societyRepository;
//        public SocietyManager(
//            ISocietyMemberAddPolicy societyMemberAddPolicy,
//            IRepository<Member> societyMemberRepository,
//            IRepository<Society, Guid> societyRepository
//            )
//        {
//            _societyMemberAddPolicy = societyMemberAddPolicy;
//            _societyMemberRepository = societyMemberRepository;
//            _societyRepository = societyRepository;

//            EventBus = NullEventBus.Instance;
//        }
//        public async Task<Member> AddMember(Society society, User user, string HouseNo)
//        {
//            return await _societyMemberRepository.InsertAsync(Member.CreateAsync(society, HouseNo, user, _societyMemberAddPolicy));
//        }

//        public async Task CreateAsync(Society society)
//        {
//            await _societyRepository.InsertAsync(society);
//        }

//        public Task<Society> GetAsync(Guid id)
//        {
//            var society = _societyRepository.FirstOrDefaultAsync(id);
//            if (society == null)
//            {
//                throw new UserFriendlyException("Couldn't found society.");
//            }

//            return society;
//        }

//        public async Task<IReadOnlyList<User>> GetMembersAsync(Society society)
//        {
//            return await _societyMemberRepository
//                .GetAll()
//                .Include(member=>member.User)
//                .Where(x => x.SocietyId == society.Id)
//                .Select(member=>member.User)
//                .ToListAsync(); 
//        }
//    }

//    public interface ISocietyManager
//    {
//        public Task<Society> GetAsync(Guid id);
//        public Task CreateAsync(Society society);
//        public Task<Member> AddMember(Society society, User user, string HouseNo);
//        public Task<IReadOnlyList<User>> GetMembersAsync(Society society);
//    }
//}
