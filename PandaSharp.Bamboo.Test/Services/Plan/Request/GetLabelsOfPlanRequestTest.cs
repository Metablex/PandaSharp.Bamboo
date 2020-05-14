using System.Threading.Tasks;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class GetLabelsOfPlanRequestTest : RequestBaseTest<GetLabelsOfPlanRequest, LabelListResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        [Test]
        public async Task GetLabelsExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/label", Method.GET);
        }

        private new IGetLabelsOfPlanRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;

            return request;
        }
    }
}