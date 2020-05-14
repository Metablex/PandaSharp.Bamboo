using System.Threading.Tasks;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    internal sealed class DeletePlanCommandTest : CommandBaseTest<DeletePlanCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        [Test]
        public async Task ExecuteAsyncTest()
        {
            await CreateCommand().ExecuteAsync();

            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}", Method.DELETE);
        }

        private IDeletePlanCommand CreateCommand()
        {
            var request = CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;

            return request;
        }
    }
}