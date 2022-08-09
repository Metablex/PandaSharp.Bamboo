using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Users.Request;
using PandaSharp.Bamboo.Services.Users.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Users.Request
{
    [TestFixture]
    internal sealed class GetCurrentUserRequestTest
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<CurrentUserResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetCurrentUserRequest, CurrentUserResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<CurrentUserResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetCurrentUserRequest, CurrentUserResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }
        
        [Test]
        public async Task SuccessfulExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<CurrentUserResponse>();
            var request = RequestTestMockBuilder.CreateRequest<GetCurrentUserRequest, CurrentUserResponse>(restFactoryMock);
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest("currentUser", Method.GET), Times.Once);
        }
    }
}