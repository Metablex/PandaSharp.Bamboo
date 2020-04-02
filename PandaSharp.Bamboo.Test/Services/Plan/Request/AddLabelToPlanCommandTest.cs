using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class AddLabelToPlanCommandTest : CommandBaseTest<AddLabelToPlanCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const string LabelKey = "BlackLabel";

        [Test]
        public async Task ExecuteAsyncTest()
        {
            GetRestRequestMock()
                .Setup(i => i.AddJsonBody(It.IsAny<object>()))
                .Callback<object>(i =>
                {
                    var json = i.ShouldBeOfType<JObject>();
                    var jsonLabelProperty = json.Children().ShouldHaveSingleItem().ShouldBeOfType<JProperty>();
                    jsonLabelProperty.Name.ShouldBe("name");

                    var jsonValue = jsonLabelProperty.Value.ShouldBeOfType<JValue>();
                    jsonValue.Value.ShouldBe(LabelKey);
                });

            await CreateRequest().ExecuteAsync();

            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/label", Method.POST);
        }

        private new AddLabelToPlanCommand CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.LabelName = LabelKey;

            return request;
        }
    }
}