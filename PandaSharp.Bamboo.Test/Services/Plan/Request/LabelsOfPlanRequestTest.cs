using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class LabelsOfPlanRequestTest : RequestBaseTest<LabelsOfPlanRequest, LabelListResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const string LabelKey = "BlackLabel";

        private JObject _jsonRequestObject;

        protected override void SetupEachTest()
        {
            _jsonRequestObject = null;

            GetRestRequestMock()
                .Setup(i => i.AddJsonBody(It.IsAny<object>()))
                .Callback<object>(i => _jsonRequestObject = i.ShouldBeOfType<JObject>());
        }

        [Test]
        public async Task GetLabelsExecuteAsyncTest()
        {
            var response = await CreateRequest(null).ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/label", Method.GET);

            _jsonRequestObject.ShouldBeNull();
        }

        [Test]
        public async Task AddLabelExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/label", Method.POST);

            _jsonRequestObject.ShouldNotBeNull();

            var jsonLabelProperty = _jsonRequestObject.Children().ShouldHaveSingleItem().ShouldBeOfType<JProperty>();
            jsonLabelProperty.Name.ShouldBe("name");

            var jsonValue = jsonLabelProperty.Value.ShouldBeOfType<JValue>();
            jsonValue.Value.ShouldBe(LabelKey);
        }

        private LabelsOfPlanRequest CreateRequest(string labelName = LabelKey)
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.LabelName = labelName;

            return request;
        }
    }
}