using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using PandaSharp.Framework.Services.Contract;
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
            var contextMock = new Mock<IRestCommunicationContext>();

            var request = RequestTestMockBuilder.CreateRequest<GetArtifactsOfPlanRequest, ArtifactListResponse>(contextMock.Object, restFactoryMock.Object);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactListResponse>(HttpStatusCode.NotFound);
            var contextMock = new Mock<IRestCommunicationContext>();

            var request = RequestTestMockBuilder.CreateRequest<GetArtifactsOfPlanRequest, ArtifactListResponse>(contextMock.Object, restFactoryMock.Object);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ArtifactListResponse>();
            var resultCountParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IResultCountParameterAspect>();

            var contextMock = new RestCommunicationContextMockBuilder()
                .WithContextValue(RequestPropertyNames.ProjectKey, ProjectKey)
                .WithContextValue(RequestPropertyNames.PlanKey, PlanKey)
                .Build();

            var request = RequestTestMockBuilder.CreateRequest<GetArtifactsOfPlanRequest, ArtifactListResponse>(
                contextMock.Object,
                restFactoryMock.Object,
                resultCountParameterAspect);

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
