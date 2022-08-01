using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class AddLabelToPlanCommandTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const string LabelKey = "BlackLabel";
        
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateCommand<AddLabelToPlanCommand>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateCommand<AddLabelToPlanCommand>(restFactoryMock);

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
                    jsonLabelProperty.Name.ShouldBe("name");

                    var jsonValue = jsonLabelProperty.Value.ShouldBeOfType<JValue>();
                    jsonValue.Value.ShouldBe(LabelKey);
                });

            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(restRequestMock: restRequestMock);
            var command = RequestTestMockBuilder.CreateCommand<AddLabelToPlanCommand>(restFactoryMock);
            command.ProjectKey = ProjectKey;
            command.PlanKey = PlanKey;
            command.LabelName = LabelKey;
            
            await command.ExecuteAsync();

            restFactoryMock.Verify(r => r.CreateRequest($"plan/{ProjectKey}-{PlanKey}/label", Method.POST), Times.Once);
        }
    }
}