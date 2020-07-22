using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;

namespace PandaSharp.Bamboo.Services.Build.Expansion
{
    public interface IBuildListInformationExpansion
    {
        void IncludingArtifacts();

        void IncludingComments();

        void IncludingLabels();

        void IncludingJiraIssues();

        void IncludingVariables();

        void IncludingStages();

        void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}