using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class AddCommentToBuildCommandTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;
        private const string Comment = "Just my 2 cents.";
        
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateCommand<AddCommentToBuildCommand>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateCommand<AddCommentToBuildCommand>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restRequestMock = new Mock<IRestRequest>();
            restRequestMock
                .Setup(i => i.AddJsonBody(It.IsAny<object>()))
                .Callback<object>(i =>
                {
                    var json = i.ShouldBeOfType<JObject>();
                    var jsonLabelProperty = json.Children().ShouldHaveSingleItem().ShouldBeOfType<JProperty>();
                    jsonLabelProperty.Name.ShouldBe("content");

                    var jsonValue = jsonLabelProperty.Value.ShouldBeOfType<JValue>();
                    jsonValue.Value.ShouldBe(Comment);
                });
            
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(restRequestMock: restRequestMock);
            var command = RequestTestMockBuilder.CreateCommand<AddCommentToBuildCommand>(restFactoryMock);
            command.ProjectKey = ProjectKey;
            command.PlanKey = PlanKey;
            command.BuildNumber = BuildNumber;
            command.Comment = Comment;
            
            await command.ExecuteAsync();
            
            restFactoryMock.Verify(r => r.CreateRequest($"result/{ProjectKey}-{PlanKey}-{BuildNumber}/comment", Method.POST), Times.Once);
        }
    }
}