using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;

namespace PandaSharp.Bamboo.Services.Build.Expansion
{
    public interface IBuildInformationExpansion
    {
        void IncludingArtifacts();

        void IncludingComments();

        void IncludingLabels();

        void IncludingJiraIssues();

        void IncludingVariables();

        void IncludingStages();

        void IncludingChanges();

        void IncludingMetaData();

        void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}