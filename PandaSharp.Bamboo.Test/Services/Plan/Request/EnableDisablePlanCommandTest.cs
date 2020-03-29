using System.Threading.Tasks;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    internal sealed class EnableDisablePlanCommandTest : CommandBaseTest<EnableDisablePlanCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        [Test]
        public async Task EnableExecuteAsyncTest()
        {
            await CreateCommand(true).ExecuteAsync();

            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/enable", Method.POST);
        }

        [Test]
        public async Task DisableExecuteAsyncTest()
        {
            await CreateCommand(false).ExecuteAsync();

            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/enable", Method.DELETE);
        }

        private EnableDisablePlanCommand CreateCommand(bool setEnabled)
        {
            var request = CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.SetEnabled = setEnabled;

            return request;
        }
    }
}