using System.Threading.Tasks;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Users.Request;
using PandaSharp.Bamboo.Services.Users.Response;
using PandaSharp.Bamboo.Test.Services.Common.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Users.Request
{
    [TestFixture]
    internal sealed class CurrentUserRequestTest : RequestBaseTest<CurrentUserRequest, CurrentUserResponse>
    {
        [Test]
        public async Task SuccessfulExecuteTest()
        {
            var request = CreateRequest();
            var response = await request.ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation("currentUser", Method.GET);
        }
    }
}