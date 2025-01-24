using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class GetInformationOfBuildRequestTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;

        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetInformationOfBuildRequest, BuildResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetInformationOfBuildRequest, BuildResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var expandState = new Mock<IBuildInformationExpansion>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildResponse>();

            var getInformationOfBuildParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IGetInformationOfBuildParameterAspect>();
            getInformationOfBuildParameterAspect
                .Setup(i => i.IncludeBuildInformation(It.IsAny<Action<IBuildInformationExpansion>[]>()))
                .Callback<Action<IBuildInformationExpansion>[]>(
                    expansions =>
                    {
                        foreach (var expansion in expansions)
                        {
                            expansion(expandState.Object);
                        }
                    });

            var request = RequestTestMockBuilder.CreateRequest<GetInformationOfBuildRequest, BuildResponse>(restFactoryMock, getInformationOfBuildParameterAspect);
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.BuildNumber = BuildNumber;

            request.IncludeBuildInformation(
                i => i.IncludingArtifacts(),
                i => i.IncludingJiraIssues());

            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();

            restFactoryMock.Verify(r => r.CreateRequest($"result/{ProjectKey}-{PlanKey}-{BuildNumber}", Method.Get), Times.Once);

            expandState.Verify(i => i.IncludingArtifacts(), Times.Once);
            expandState.Verify(i => i.IncludingComments(), Times.Never);
            expandState.Verify(i => i.IncludingLabels(), Times.Never);
            expandState.Verify(i => i.IncludingStages(), Times.Never);
            expandState.Verify(i => i.IncludingVariables(), Times.Never);
            expandState.Verify(i => i.IncludingJiraIssues(), Times.Once);
            expandState.Verify(i => i.IncludingChanges(), Times.Never);
            expandState.Verify(i => i.IncludingMetaData(), Times.Never);
        }
    }
}
