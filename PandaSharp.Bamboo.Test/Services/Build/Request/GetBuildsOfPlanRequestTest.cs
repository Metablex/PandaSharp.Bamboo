using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class GetBuildsOfPlanRequestTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildListResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetBuildsOfPlanRequest, BuildListResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildListResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetBuildsOfPlanRequest, BuildListResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task AllBuildsExecuteAsyncTest()
        {
            var expandState = new Mock<IBuildListInformationExpansion>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildListResponse>();
            var resultCountParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IResultCountParameterAspect>();
            var buildStateParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IBuildStateParameterAspect>();
            var issueFilterParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IIssueFilterParameterAspect>();
            var labelFilterParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<ILabelFilterParameterAspect>();
            
            var getBuildsOfPlanParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IGetBuildsOfPlanParameterAspect>();
            getBuildsOfPlanParameterAspect
                .Setup(i => i.IncludeBuildInformation(It.IsAny<Action<IBuildListInformationExpansion>[]>()))
                .Callback<Action<IBuildListInformationExpansion>[]>(
                    expansions =>
                    {
                        foreach (var expansion in expansions)
                        {
                            expansion(expandState.Object);
                        }
                    });

            var request = RequestTestMockBuilder
                .CreateRequest<GetBuildsOfPlanRequest, BuildListResponse>(restFactoryMock, resultCountParameterAspect, buildStateParameterAspect, issueFilterParameterAspect, labelFilterParameterAspect, getBuildsOfPlanParameterAspect)
                .WithMaxResult(10)
                .StartAtIndex(5)
                .OnlySuccessfulBuilds()
                .OnlyWithIssues("Issue1", "Issue2")
                .OnlyWithLabels("BlueLabel", "RedLabel", "BlackLabel")
                .IncludeBuildInformation(i => i.IncludingArtifacts(), i => i.IncludingJiraIssues());
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest("result", Method.GET), Times.Once);
            
            resultCountParameterAspect.Verify(i => i.SetMaxResults(10), Times.Once);
            resultCountParameterAspect.Verify(i => i.SetStartIndex(5), Times.Once);
            buildStateParameterAspect.Verify(i => i.SetBuildStateFilter(BuildState.Successful), Times.Once);
            issueFilterParameterAspect.Verify(i => i.SetIssuesFilter(new[] { "Issue1", "Issue2" }), Times.Once);
            labelFilterParameterAspect.Verify(i => i.SetLabelsFilter(new[] { "BlueLabel", "RedLabel", "BlackLabel" }), Times.Once);
            
            expandState.Verify(i => i.IncludingArtifacts(), Times.Once);
            expandState.Verify(i => i.IncludingComments(), Times.Never);
            expandState.Verify(i => i.IncludingLabels(), Times.Never);
            expandState.Verify(i => i.IncludingStages(), Times.Never);
            expandState.Verify(i => i.IncludingVariables(), Times.Never);
            expandState.Verify(i => i.IncludingJiraIssues(), Times.Once);
        }

        [Test]
        public async Task OneBuildsExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BuildListResponse>();
            
            var request = RequestTestMockBuilder.CreateRequest<GetBuildsOfPlanRequest, BuildListResponse>(restFactoryMock);
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest($"result/{ProjectKey}-{PlanKey}", Method.GET), Times.Once);
        }
    }
}