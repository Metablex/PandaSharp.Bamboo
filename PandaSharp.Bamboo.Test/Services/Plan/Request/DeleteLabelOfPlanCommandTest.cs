using System.Threading.Tasks;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class DeleteLabelOfPlanCommandTest : CommandBaseTest<DeleteLabelOfPlanCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const string LabelKey = "BlackLabel";

        [Test]
        public async Task ExecuteAsyncTest()
        {
            await CreateCommand().ExecuteAsync();

            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/label/{LabelKey}", Method.DELETE);
        }

        private IDeleteLabelOfPlanCommand CreateCommand()
        {
            var request = CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.LabelName = LabelKey;

            return request;
        }
    }
}