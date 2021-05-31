using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class GetBranchesOfPlanRequestTest : RequestBaseTest<GetBranchesOfPlanRequest, BranchListResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
            yield return CreateParameterAspectMock<IGetBranchesOfPlanParameterAspect>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/branch", Method.GET);
        }

        [Test]
        public void ResultCountParameterAspectTest()
        {
            CreateRequest()
                .WithMaxResult(12)
                .StartAtIndex(3);

            VerifyParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(12);
                aspect.StartIndex.ShouldBe(3);
            });
        }

        [Test]
        public void BranchesOfPlanParameterAspectTest()
        {
            CreateRequest().OnlyEnabledBranches();

            VerifyParameterAspectMock<IGetBranchesOfPlanParameterAspect>(aspect =>
            {
                aspect.OnlyEnabledBranches.ShouldBeTrue();
            });
        }

        private new GetBranchesOfPlanRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;

            return request;
        }
    }
}