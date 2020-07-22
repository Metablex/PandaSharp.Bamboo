using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Expansion
{
    [TestFixture]
    public sealed class PlanListInformationExpansionTest
    {
        [Test]
        public void ToStringTest()
        {
            var expansion = new PlanListInformationExpansion("test");

            var actual = expansion.ToString();
            actual.ShouldBe("test");

            expansion.IncludeBranches();
            expansion.IncludeActions();
            expansion.IncludeStages();

            actual = expansion.ToString();
            actual.ShouldBe("test.branches,test.actions,test.stages");
        }
    }
}