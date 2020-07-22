using System;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Common.Contract;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface IGetBuildsOfPlanRequest : IRequestBase<BuildListResponse>
    {
        IGetBuildsOfPlanRequest WithMaxResult(int maxResult);

        IGetBuildsOfPlanRequest StartAtIndex(int startIndex);

        IGetBuildsOfPlanRequest OnlyFailedBuilds();

        IGetBuildsOfPlanRequest OnlySuccessfulBuilds();

        IGetBuildsOfPlanRequest OnlyUncompletedBuilds();

        IGetBuildsOfPlanRequest OnlyWithIssues(params string[] jiraIssues);

        IGetBuildsOfPlanRequest OnlyWithLabels(params string[] labels);

        IGetBuildsOfPlanRequest IncludeBuildInformation(params Action<IBuildListInformationExpansion>[] expansions);
    }
}