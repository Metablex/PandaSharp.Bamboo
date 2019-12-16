using PandaSharp.Services.Build.Response;
using PandaSharp.Services.Common.Contract;

namespace PandaSharp.Services.Build.Contract
{
    public interface IBuildListRequest : IRequestBase<BuildListResponse>
    {
        IBuildListRequest WithMaxResult(int maxResult);

        IBuildListRequest StartAtIndex(int startIndex);

        IBuildListRequest OnlyFailedBuilds();

        IBuildListRequest OnlySuccessfulBuilds();

        IBuildListRequest OnlyUncompletedBuilds();

        IBuildListRequest OnlyWithIssues(params string[] jiraIssues);

        IBuildListRequest OnlyWithLabels(params string[] labels);

        IBuildListRequest IncludingDetails();

        IBuildListRequest IncludingArtifacts();

        IBuildListRequest IncludingComments();

        IBuildListRequest IncludingLabels();

        IBuildListRequest IncludingJiraIssues();

        IBuildListRequest IncludingVariables();

        IBuildListRequest IncludingStages();
    }
}