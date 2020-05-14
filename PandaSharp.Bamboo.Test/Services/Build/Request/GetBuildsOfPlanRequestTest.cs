using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using PandaSharp.Bamboo.Utils;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class GetBuildsOfPlanRequestTest : RequestBaseTest<GetBuildsOfPlanRequest, BuildListResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        private BuildListExpandState? _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
            yield return CreateParameterAspectMock<IBuildStateParameterAspect>();
            yield return CreateParameterAspectMock<IIssueFilterParameterAspect>();
            yield return CreateParameterAspectMock<ILabelFilterParameterAspect>();
            yield return CreateParameterAspectMock<IExpandStateParameterAspect<BuildListExpandState>>();
        }

        protected override void SetupEachTest()
        {
            _expandState = null;

            var expandStateMock = GetParameterAspectMock<IExpandStateParameterAspect<BuildListExpandState>>();
            expandStateMock
                .Setup(i => i.AddExpandState(It.IsAny<BuildListExpandState>()))
                .Callback<BuildListExpandState>(state => _expandState.AddEnumMember(state));
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
        public void ExpandStateParameterAspectTest()
        {
            CreateRequest()
                .IncludingArtifacts()
                .IncludingComments()
                .IncludingDetails()
                .IncludingLabels()
                .IncludingStages()
                .IncludingVariables()
                .IncludingJiraIssues();

            VerifyParameterAspectMock<IExpandStateParameterAspect<BuildListExpandState>>(aspect =>
            {
                _expandState.ShouldNotBeNull();
                _expandState.ShouldBe(
                    BuildListExpandState.IncludingArtifacts
                    | BuildListExpandState.IncludingComments
                    | BuildListExpandState.IncludingDetails
                    | BuildListExpandState.IncludingLabels
                    | BuildListExpandState.IncludingStages
                    | BuildListExpandState.IncludingVariables
                    | BuildListExpandState.IncludingJiraIssues);
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