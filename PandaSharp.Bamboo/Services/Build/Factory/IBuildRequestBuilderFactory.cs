using PandaSharp.Bamboo.Services.Build.Contract;

namespace PandaSharp.Bamboo.Services.Build.Factory
{
    public interface IBuildRequestBuilderFactory
    {
        IGetBuildsOfPlanRequest GetAllBuilds();

        IGetBuildsOfPlanRequest GetBuildsOfPlan(string projectKey, string planKey);

        IGetInformationOfBuildRequest GetInformationOfBuild(string projectKey, string planKey, uint buildNumber);

        IGetInformationOfBuildRequest GetInformationOfLatestBuild(string projectKey, string planKey);

        IGetCommentsOfBuildRequest GetCommentsOfBuild(string projectKey, string planKey, uint buildNumber);

        IAddCommentToBuildCommand AddCommentToBuild(string projectKey, string planKey, uint buildNumber, string comment);

        IGetLabelsOfBuildRequest GetLabelsOfBuild(string projectKey, string planKey, uint buildNumber);

        IAddLabelToBuildCommand AddLabelToBuild(string projectKey, string planKey, uint buildNumber, string label);

        IDeleteLabelOfBuildCommand DeleteLabelOfBuild(string projectKey, string planKey, uint buildNumber, string label);
    }
}