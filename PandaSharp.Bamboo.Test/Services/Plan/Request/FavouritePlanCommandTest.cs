using System.Threading.Tasks;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class FavouritePlanCommandTest : CommandBaseTest<FavouritePlanCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        [Test]
        public async Task FavouriteExecuteAsyncTest()
        {
            await CreateCommand(true).ExecuteAsync();

            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/favourite", Method.POST);
        }

        [Test]
        public async Task UnfavouriteExecuteAsyncTest()
        {
            await CreateCommand(false).ExecuteAsync();

            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/favourite", Method.DELETE);
        }

        private FavouritePlanCommand CreateCommand(bool setFavourite)
        {
            var request = CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.SetFavourite = setFavourite;

            return request;
        }
    }
}