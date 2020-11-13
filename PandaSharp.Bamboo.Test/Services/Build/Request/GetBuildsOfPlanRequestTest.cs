using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
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
    internal sealed class GetBuildsOfPlanRequestTest : RequestBaseTest<GetBuildsOfPlanRequest, BuildListResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        private Mock<IBuildListInformationExpansion> _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
            yield return CreateParameterAspectMock<IBuildStateParameterAspect>();
            yield return CreateParameterAspectMock<IIssueFilterParameterAspect>();
            yield return CreateParameterAspectMock<ILabelFilterParameterAspect>();
            yield return CreateParameterAspectMock<IGetBuildsOfPlanParameterAspect>(
                aspect =>
                {
                    aspect
                        .Setup(i => i.IncludeBuildInformation(It.IsAny<Action<IBuildListInformationExpansion>[]>()))
                        .Callback<Action<IBuildListInformationExpansion>[]>(
                            expansions =>
                            {
                                foreach (var expansion in expansions)
                                {
                                    expansion(_expandState.Object);
                                }
                            });
                });
        }

        protected override void SetupEachTest()
        {
            _expandState = new Mock<IBuildListInformationExpansion>();
        }

        [Test]
        public async Task OneBuildsExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"result/{ProjectKey}-{PlanKey}", Method.GET);
        }

        [Test]
        public async Task AllBuildsExecuteAsyncTest()
        {
            var response = await CreateRequest(null, null).ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation("result", Method.GET);
        }

        [Test]
        public void ResultCountParameterAspectTest()
        {
            CreateRequest()
                .WithMaxResult(10)
                .StartAtIndex(5);

            VerifyParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(10);
                aspect.StartIndex.ShouldBe(5);
            });
        }

        [Test]
        public void BuildStateParameterAspectTest()
        {
            VerifyParameterAspectMock<IBuildStateParameterAspect>(aspect =>
            {
                aspect.BuildState.ShouldBeNull();
            });

            CreateRequest().OnlySuccessfulBuilds();

            VerifyParameterAspectMock<IBuildStateParameterAspect>(aspect =>
            {
                aspect.BuildState.ShouldBe(BuildState.Successful);
            });

            CreateRequest().OnlyFailedBuilds();

            VerifyParameterAspectMock<IBuildStateParameterAspect>(aspect =>
            {
                aspect.BuildState.ShouldBe(BuildState.Failed);
            });

            CreateRequest().OnlyUncompletedBuilds();

            VerifyParameterAspectMock<IBuildStateParameterAspect>(aspect =>
            {
                aspect.BuildState.ShouldBe(BuildState.Unknown);
            });
        }

        [Test]
        public void IssueFilterParameterAspectTest()
        {
            CreateRequest().OnlyWithIssues("Issue1", "Issue2");

            VerifyParameterAspectMock<IIssueFilterParameterAspect>(aspect =>
            {
                aspect.Issues.ShouldBe(new[] { "Issue1", "Issue2" }, true);
            });
        }

        [Test]
        public void LabelFilterParameterAspectTest()
        {
            CreateRequest().OnlyWithLabels("BlueLabel", "RedLabel", "BlackLabel");

            VerifyParameterAspectMock<ILabelFilterParameterAspect>(aspect =>
            {
                aspect.Labels.ShouldBe(new[] { "BlueLabel", "RedLabel", "BlackLabel" }, true);
            });
        }

        [Test]
        public void GetBuildsOfPlanParameterAspectTest()
        {
            CreateRequest()
                .IncludeBuildInformation(
                    i => i.IncludingArtifacts(),
                    i => i.IncludingJiraIssues());

            VerifyParameterAspectMock<IGetBuildsOfPlanParameterAspect>(aspect =>
            {
                _expandState.Verify(i => i.IncludingArtifacts(), Times.Once);
                _expandState.Verify(i => i.IncludingComments(), Times.Never);
                _expandState.Verify(i => i.IncludingLabels(), Times.Never);
                _expandState.Verify(i => i.IncludingStages(), Times.Never);
                _expandState.Verify(i => i.IncludingVariables(), Times.Never);
                _expandState.Verify(i => i.IncludingJiraIssues(), Times.Once);
            });
        }

        private IGetBuildsOfPlanRequest CreateRequest(string projectKey = ProjectKey, string planKey = PlanKey)
        {
            var request = base.CreateRequest();
            request.ProjectKey = projectKey;
            request.PlanKey = planKey;

            return request;
        }
    }
}