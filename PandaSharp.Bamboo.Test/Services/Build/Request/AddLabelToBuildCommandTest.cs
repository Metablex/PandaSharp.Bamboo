using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class AddLabelToBuildCommandTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;
        private const string Label = "BlackLabel";

        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateCommand<AddLabelToBuildCommand>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateCommand<AddLabelToBuildCommand>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock();
            var command = RequestTestMockBuilder.CreateCommand<AddLabelToBuildCommand>(restFactoryMock);
            command.ProjectKey = ProjectKey;
            command.PlanKey = PlanKey;
            command.BuildNumber = BuildNumber;
            command.Label = Label;

            await command.ExecuteAsync();

            restFactoryMock.Verify(r => r.CreateRequest($"result/{ProjectKey}-{PlanKey}-{BuildNumber}/label", Method.Post), Times.Once);
        }
    }
}
