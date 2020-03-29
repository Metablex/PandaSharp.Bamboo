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
    internal sealed class AllPlansRequestTest : RequestBaseTest<AllPlansRequest, PlanListResponse>
    {
        private PlansExpandState? _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
            yield return CreateParameterAspectMock<IExpandStateParameterAspect<PlansExpandState>>();
        }

        protected override void SetupEachTest()
        {
            _expandState = null;

            var expandStateMock = GetParameterAspectMock<IExpandStateParameterAspect<PlansExpandState>>();
            expandStateMock
                .Setup(i => i.AddExpandState(It.IsAny<PlansExpandState>()))
                .Callback<PlansExpandState>(state => _expandState.AddEnumMember(state));
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation("plan", Method.GET);
        }

        [Test]
        public void ResultCountParameterAspectOptionsTest()
        {
            CreateRequest()
                .WithMaxResult(45)
                .StartAtIndex(7);

            VerifyParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(45);
                aspect.StartIndex.ShouldBe(7);
            });
        }

        [Test]
        public void ExpandStateParameterAspectTest()
        {
            CreateRequest()
                .IncludeActions()
                .IncludeBranches()
                .IncludeDetails()
                .IncludeStages();

            VerifyParameterAspectMock<IExpandStateParameterAspect<PlansExpandState>>(aspect =>
            {
                _expandState.ShouldNotBeNull();
                _expandState.ShouldBe(
                    PlansExpandState.IncludingActions
                    | PlansExpandState.IncludingBranches
                    | PlansExpandState.IncludingDetails
                    | PlansExpandState.IncludingStages);
            });
        }
    }
}