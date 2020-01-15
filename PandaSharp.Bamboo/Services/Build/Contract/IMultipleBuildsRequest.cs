using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Common.Contract;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface IMultipleBuildsRequest : IRequestBase<BuildListResponse>
    {
        IMultipleBuildsRequest WithMaxResult(int maxResult);

        IMultipleBuildsRequest StartAtIndex(int startIndex);

        IMultipleBuildsRequest OnlyFailedBuilds();

        IMultipleBuildsRequest OnlySuccessfulBuilds();

        IMultipleBuildsRequest OnlyUncompletedBuilds();

        IMultipleBuildsRequest OnlyWithIssues(params string[] jiraIssues);

        IMultipleBuildsRequest OnlyWithLabels(params string[] labels);

        IMultipleBuildsRequest IncludingDetails();

        IMultipleBuildsRequest IncludingArtifacts();

        IMultipleBuildsRequest IncludingComments();

        IMultipleBuildsRequest IncludingLabels();

        IMultipleBuildsRequest IncludingJiraIssues();

        IMultipleBuildsRequest IncludingVariables();

        IMultipleBuildsRequest IncludingStages();
    }
}