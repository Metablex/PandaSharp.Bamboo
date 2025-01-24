using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class GetLabelsOfBuildRequestTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;

        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<LabelListResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetLabelsOfBuildRequest, LabelListResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<LabelListResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetLabelsOfBuildRequest, LabelListResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<LabelListResponse>();

            var request = RequestTestMockBuilder.CreateRequest<GetLabelsOfBuildRequest, LabelListResponse>(restFactoryMock);
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.BuildNumber = BuildNumber;

            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();

            restFactoryMock.Verify(r => r.CreateRequest($"result/{ProjectKey}-{PlanKey}-{BuildNumber}/label", Method.Get), Times.Once);
        }
    }
}
