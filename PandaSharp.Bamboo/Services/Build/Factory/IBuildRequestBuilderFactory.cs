using PandaSharp.Bamboo.Services.Build.Contract;

namespace PandaSharp.Bamboo.Services.Build.Factory
{
    public interface IBuildRequestBuilderFactory
    {
        IMultipleBuildsRequest AllBuilds();

        IMultipleBuildsRequest BuildsOfPlan(string projectKey, string planKey);

        ISingleBuildRequest InformationOfBuild(string projectKey, string planKey, uint buildNumber);

        ISingleBuildRequest InformationOfLatestBuild(string projectKey, string planKey);

        ICommentsOfBuildRequest CommentsOfBuild(string projectKey, string planKey, uint buildNumber);

        ILabelsOfBuildRequest LabelsOfBuild(string projectKey, string planKey, uint buildNumber);
    }
}