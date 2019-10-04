using PandaSharp.Services.Build.Response;
using PandaSharp.Services.Common.Contract;

namespace PandaSharp.Services.Build.Contract
{
    public interface IBuildsRequest : IRequestBase<BuildsResponse>
    {
        IBuildsRequest WithMaxResult(int maxResult);

        IBuildsRequest StartAtIndex(int startIndex);

        IBuildsRequest OnlyFailedBuilds();

        IBuildsRequest OnlySuccessfulBuilds();

        IBuildsRequest OnlyUncompletedBuilds();

        IBuildsRequest OnlyWithIssues(params string[] jiraIssues);

        IBuildsRequest OnlyWithLabels(params string[] labels);

        IBuildsRequest IncludingDetails();

        IBuildsRequest IncludingArtifacts();

        IBuildsRequest IncludingComments();

        IBuildsRequest IncludingLabels();

        IBuildsRequest IncludingJiraIssues();

        IBuildsRequest IncludingVariables();

        IBuildsRequest IncludingStages();
    }
}