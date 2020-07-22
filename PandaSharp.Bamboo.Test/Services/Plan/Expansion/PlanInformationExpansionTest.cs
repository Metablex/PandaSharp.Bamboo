using Castle.Core.Internal;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Expansion
{
    [TestFixture]
    public sealed class PlanInformationExpansionTest
    {
        [Test]
        public void ToStringTest()
        {
            var expansion = new PlanInformationExpansion();

            var actual = expansion.ToString();
            actual.IsNullOrEmpty().ShouldBeTrue();

            expansion.IncludeBranches();
            expansion.IncludeActions();
            expansion.IncludeVariableContext();
            expansion.IncludeStages();

            actual = expansion.ToString();
            actual.ShouldBe("branches,actions,variableContext,stages");
        }
    }
}