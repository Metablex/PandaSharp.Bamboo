namespace PandaSharp.Services.Build.Contract
{
    public interface IBuildRequestBuilderFactory
    {
        IBuildListRequest AllBuilds();

        IBuildListRequest BuildsOfPlan(string projectKey, string planKey);

        IBuildRequest InformationOfBuild(string projectKey, string planKey, uint buildNumber);

        IBuildRequest InformationOfLatestBuild(string projectKey, string planKey);

        ICommentsOfBuildRequest CommentsOfBuild(string projectKey, string planKey, uint buildNumber);

        ILabelsOfBuildRequest LabelsOfBuild(string projectKey, string planKey, uint buildNumber);
    }
}