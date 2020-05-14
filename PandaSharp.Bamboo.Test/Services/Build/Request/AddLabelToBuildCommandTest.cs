using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    internal sealed class AddLabelToBuildCommandTest : CommandBaseTest<AddLabelToBuildCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;
        private const string Label = "BlackLabel";

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
                    jsonValue.Value.ShouldBe(Label);
                });

            await CreateRequest().ExecuteAsync();

            VerifyRestRequestCreation($"result/{ProjectKey}-{PlanKey}-{BuildNumber}/label", Method.POST);
        }

        private new IAddLabelToBuildCommand CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.BuildNumber = BuildNumber;
            request.Label = Label;

            return request;
        }
    }
}