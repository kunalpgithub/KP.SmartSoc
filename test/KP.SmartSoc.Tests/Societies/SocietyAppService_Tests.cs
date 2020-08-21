using KP.SmartSoc.Society;
using KP.SmartSoc.Society.Dtos;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KP.SmartSoc.Tests.Societies
{
    public class SocietyAppService_Tests : SmartSocTestBase
    {
        private readonly ISocietyAppService _societyAppService;

        public SocietyAppService_Tests()
        {
            _societyAppService = Resolve<ISocietyAppService>();
        }

        [Fact]
        public async Task Should_Get_Test_Societies() {
            var output = await _societyAppService.GetAllAsync(new PagedSocietyResultRequestDto { Keyword="",SkipCount=0,MaxResultCount=10 });
            output.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Create_Society() {
            var address = "Motera";

            await _societyAppService.CreateAsync(new CreateScoietyDto
            {
                
                Address = address,
                City = "Ahmedabad",
                Country = "India",
                FullName = "Devnandan Infinity",
                RegistrationNumber = "12314DNH124",
                State = "Gujarat",
                Zipcode = "380005",
            });
            UsingDbContext(context=> {
                context.Societies.FirstOrDefault(x => x.Address == address).ShouldNotBeNull();
            })
            ;
        }
        
    }
}
