using NUnit.Framework;
using PandaSharp;
using PandaSharp.Utils;

namespace Tests
{
    [TestFixture]
    public class BamboConnectionTest
    {
        [Test]
        public void Test()
        {
            var api = new BambooApi("http://qoniac.bamboo.com", "user", "password");

            var test = api
                .PlanRequest
                .GetAllPlans()
                .WithMaxResult(30)
                .IncludeDetails()
                .Execute();
        }
    }
}