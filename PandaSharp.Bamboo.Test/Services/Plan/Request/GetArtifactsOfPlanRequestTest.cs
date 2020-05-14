using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class GetArtifactsOfPlanRequestTest : RequestBaseTest<GetArtifactsOfPlanRequest, ArtifactListResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/artifact", Method.GET);
        }

        [Test]
        public void ResultCountParameterAspectTest()
        {
            CreateRequest()
                .StartAtIndex(5)
                .WithMaxResult(55);

            VerifyParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(55);
                aspect.StartIndex.ShouldBe(5);
            });
        }

        private new IGetArtifactsOfPlanRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;

            return request;
        }
    }
}