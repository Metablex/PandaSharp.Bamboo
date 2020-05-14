using System.Threading.Tasks;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class GetCommentsOfBuildRequestTest : RequestBaseTest<GetCommentsOfBuildRequest, CommentListResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"result/{ProjectKey}-{PlanKey}-{BuildNumber}/comment", Method.GET);
        }

        private new IGetCommentsOfBuildRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.BuildNumber = BuildNumber;

            return request;
        }
    }
}