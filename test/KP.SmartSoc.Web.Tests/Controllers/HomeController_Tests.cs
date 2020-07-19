using System.Threading.Tasks;
using KP.SmartSoc.Models.TokenAuth;
using KP.SmartSoc.Web.Controllers;
using Shouldly;
using Xunit;

namespace KP.SmartSoc.Web.Tests.Controllers
{
    public class HomeController_Tests: SmartSocWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}