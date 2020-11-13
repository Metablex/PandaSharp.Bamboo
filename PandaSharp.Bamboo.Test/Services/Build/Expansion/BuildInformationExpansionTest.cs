using Castle.Core.Internal;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Expansion;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Expansion
{
    [TestFixture]
    public sealed class BuildInformationExpansionTest
    {
        [Test]
        public void ToStringTest()
        {
            var expansion = new BuildInformationExpansion();
            expansion.ToString().IsNullOrEmpty().ShouldBeTrue();

            expansion.IncludingArtifacts();
            expansion.IncludingComments();
            expansion.IncludingLabels();
            expansion.IncludingJiraIssues();
            expansion.IncludingVariables();
            expansion.IncludingStages();
            expansion.IncludingChanges();
            expansion.IncludingMetaData();
            expansion.ToString().ShouldBe("artifacts,comments,labels,jiraIssues,variables,stages,changes,metadata");

            expansion.IncludePlanInformation();
            expansion.ToString().ShouldBe("artifacts,comments,labels,jiraIssues,variables,stages,changes,metadata,plan");

            expansion.IncludePlanInformation(i => i.IncludeActions());
            expansion.ToString().ShouldBe("artifacts,comments,labels,jiraIssues,variables,stages,changes,metadata,plan.actions");

            expansion.IncludePlanInformation(i => i.IncludeBranches());
            expansion.ToString().ShouldBe("artifacts,comments,labels,jiraIssues,variables,stages,changes,metadata,plan.branches");
        }
    }
}