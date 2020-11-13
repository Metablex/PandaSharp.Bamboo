using Castle.Core.Internal;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Expansion;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Expansion
{
    [TestFixture]
    public sealed class BuildListInformationExpansionTest
    {
        [Test]
        public void ToStringTest()
        {
            var expansion = new BuildListInformationExpansion();
            expansion.ToString().ShouldBe("results.result");

            expansion.IncludingArtifacts();
            expansion.IncludingComments();
            expansion.IncludingLabels();
            expansion.IncludingJiraIssues();
            expansion.IncludingVariables();
            expansion.IncludingStages();
            expansion.ToString().ShouldBe("results.result.artifacts,results.result.comments,results.result.labels,results.result.jiraIssues,results.result.variables,results.result.stages");

            expansion.IncludePlanInformation();
            expansion.ToString().ShouldBe("results.result.artifacts,results.result.comments,results.result.labels,results.result.jiraIssues,results.result.variables,results.result.stages,results.result.plan");

            expansion.IncludePlanInformation(i => i.IncludeActions());
            expansion.ToString().ShouldBe("results.result.artifacts,results.result.comments,results.result.labels,results.result.jiraIssues,results.result.variables,results.result.stages,results.result.plan.actions");

            expansion.IncludePlanInformation(i => i.IncludeBranches());
            expansion.ToString().ShouldBe("results.result.artifacts,results.result.comments,results.result.labels,results.result.jiraIssues,results.result.variables,results.result.stages,results.result.plan.branches");
        }
    }
}