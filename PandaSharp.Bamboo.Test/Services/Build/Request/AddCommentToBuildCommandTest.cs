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
    internal sealed class AddCommentToBuildCommandTest : CommandBaseTest<AddCommentToBuildCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;
        private const string Comment = "Just my 2 cents.";

        [Test]
        public async Task ExecuteAsyncTest()
        {
            GetRestRequestMock()
                .Setup(i => i.AddJsonBody(It.IsAny<object>()))
                .Callback<object>(i =>
                {
                    var json = i.ShouldBeOfType<JObject>();
                    var jsonLabelProperty = json.Children().ShouldHaveSingleItem().ShouldBeOfType<JProperty>();
                    jsonLabelProperty.Name.ShouldBe("content");

                    var jsonValue = jsonLabelProperty.Value.ShouldBeOfType<JValue>();
                    jsonValue.Value.ShouldBe(Comment);
                });

            await CreateRequest().ExecuteAsync();

            VerifyRestRequestCreation($"result/{ProjectKey}-{PlanKey}-{BuildNumber}/comment", Method.POST);
        }

        private new IAddCommentToBuildCommand CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.BuildNumber = BuildNumber;
            request.Comment = Comment;

            return request;
        }
    }
}