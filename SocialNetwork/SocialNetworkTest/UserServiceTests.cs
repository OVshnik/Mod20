using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetworkTest
{
    public class UserServiceTests
    {
        [Fact]
        public void Test1()
        {
            var moqUserService = new UserService();
            var moqUserAuthData = new UserAuthenticationData();
            moqUserAuthData.Email = "test";
            Assert.Throws<UserNotFoundException>(() => moqUserService.Authenticate(moqUserAuthData));
        }
    }
}