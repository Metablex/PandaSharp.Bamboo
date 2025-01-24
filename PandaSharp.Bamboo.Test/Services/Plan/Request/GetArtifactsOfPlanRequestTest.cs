using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class GetArtifactsOfPlanRequestTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactListResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetArtifactsOfPlanRequest, ArtifactListResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactListResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetArtifactsOfPlanRequest, ArtifactListResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactListResponse>();
            var resultCountParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IResultCountParameterAspect>();

            var request = RequestTestMockBuilder.CreateRequest<GetArtifactsOfPlanRequest, ArtifactListResponse>(restFactoryMock, resultCountParameterAspect);
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;

            request
                .StartAtIndex(5)
                .WithMaxResult(55);

            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();

            restFactoryMock.Verify(r => r.CreateRequest($"plan/{ProjectKey}-{PlanKey}/artifact", Method.Get), Times.Once);

            resultCountParameterAspect.Verify(i => i.SetMaxResults(55), Times.Once);
            resultCountParameterAspect.Verify(i => i.SetStartIndex(5), Times.Once);
        }
    }
}
