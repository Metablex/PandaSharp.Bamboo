using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Bamboo.Services.Plan.Types;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using PandaSharp.Bamboo.Utils;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class InformationOfPlanRequestTest : RequestBaseTest<InformationOfPlanRequest, PlanResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        private PlanExpandState? _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
            yield return CreateParameterAspectMock<IExpandStateParameterAspect<PlanExpandState>>();
        }

        protected override void SetupEachTest()
        {
            _expandState = null;

            var expandStateMock = GetParameterAspectMock<IExpandStateParameterAspect<PlanExpandState>>();
            expandStateMock
                .Setup(i => i.AddExpandState(It.IsAny<PlanExpandState>()))
                .Callback<PlanExpandState>(state => _expandState.AddEnumMember(state));
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}", Method.GET);
        }

        [Test]
        public void ExpandStateParameterAspectTest()
        {
            CreateRequest()
                .IncludeActions()
                .IncludeStages()
                .IncludeVariableContext()
                .IncludeBranches(30);

            VerifyParameterAspectMock<IExpandStateParameterAspect<PlanExpandState>>(aspect =>
            {
                _expandState.ShouldNotBeNull();
                _expandState.ShouldBe(
                    PlanExpandState.IncludingActions
                    | PlanExpandState.IncludingBranches
                    | PlanExpandState.IncludingVariableContext
                    | PlanExpandState.IncludingStages);
            });
        }

        private new InformationOfPlanRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;

            return request;
        }
    }
}