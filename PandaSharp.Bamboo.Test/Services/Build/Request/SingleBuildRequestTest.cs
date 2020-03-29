using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
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
    internal sealed class SingleBuildRequestTest : RequestBaseTest<SingleBuildRequest, BuildResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const string BuildNumber = "42";

        private BuildExpandState? _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IExpandStateParameterAspect<BuildExpandState>>();
        }

        protected override void SetupEachTest()
        {
            _expandState = null;

            var expandStateMock = GetParameterAspectMock<IExpandStateParameterAspect<BuildExpandState>>();
            expandStateMock
                .Setup(i => i.AddExpandState(It.IsAny<BuildExpandState>()))
                .Callback<BuildExpandState>(state => _expandState.AddEnumMember(state));
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"result/{ProjectKey}-{PlanKey}-{BuildNumber}", Method.GET);
        }

        [Test]
        public void ExpandStateParameterAspectTest()
        {
            CreateRequest()
                .IncludingArtifacts()
                .IncludingChanges()
                .IncludingComments()
                .IncludingLabels()
                .IncludingStages()
                .IncludingVariables()
                .IncludingJiraIssues()
                .IncludingMetaData();

            VerifyParameterAspectMock<IExpandStateParameterAspect<BuildExpandState>>(aspect =>
            {
                _expandState.ShouldNotBeNull();
                _expandState.ShouldBe(
                    BuildExpandState.IncludingArtifacts
                    | BuildExpandState.IncludingChanges
                    | BuildExpandState.IncludingComments
                    | BuildExpandState.IncludingLabels
                    | BuildExpandState.IncludingStages
                    | BuildExpandState.IncludingVariables
                    | BuildExpandState.IncludingJiraIssues
                    | BuildExpandState.IncludingMetaData);
            });
        }

        private new SingleBuildRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.BuildNumber = BuildNumber;

            return request;
        }
    }
}