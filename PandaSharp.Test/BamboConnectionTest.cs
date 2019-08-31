using System.IO;
using System.Linq;
using NUnit.Framework;
using PandaSharp.Utils;

namespace PandaSharp.Test
{
    [TestFixture]
    public class BamboConnectionTest
    {
        [Test]
        public void Test()
        {
            var api = new BambooApi("https://bamboo.qoniac.com", TestConstants.UserName, TestConstants.Password);

            var request = api
                .PlanRequest
                .AllPlans()
                .WithMaxResult(117)
                .IncludeDetails()
                .IncludeActionsInformation()
                .IncludeBranchesInformation()
                .IncludeStagesInformation();

            var json = request.DownloadData();
            var response = request.Execute();

            var plan = response.First(p => p.Actions.Size > 0);
            foreach (var action in plan.Actions)
            {

            }

            File.WriteAllText(@"C:\Users\tom.birras\Downloads\PandaSharpData\allplans.json", json);
        }
    }
}