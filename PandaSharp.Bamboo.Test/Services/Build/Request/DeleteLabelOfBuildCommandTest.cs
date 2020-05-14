using System.Threading.Tasks;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class DeleteLabelOfBuildCommandTest : CommandBaseTest<DeleteLabelOfBuildCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;
        private const string Label = "BlackLabel";

        [Test]
        public async Task ExecuteAsyncTest()
        {
            await CreateRequest().ExecuteAsync();

            VerifyRestRequestCreation($"result/{ProjectKey}-{PlanKey}-{BuildNumber}/label/{Label}", Method.DELETE);
        }

        private new IDeleteLabelOfBuildCommand CreateRequest()
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