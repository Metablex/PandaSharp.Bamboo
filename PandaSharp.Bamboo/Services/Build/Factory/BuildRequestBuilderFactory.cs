using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.IoC.Injections;

namespace PandaSharp.Bamboo.Services.Build.Factory
{
    internal sealed class BuildRequestBuilderFactory : IBuildRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public BuildRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IGetBuildsOfPlanRequest GetAllBuilds()
        {
            return _container.Resolve<IGetBuildsOfPlanRequest>();
        }

        public IGetBuildsOfPlanRequest GetBuildsOfPlan(string projectKey, string planKey)
        {
            return _container.Resolve<IGetBuildsOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey));
        }

        public IGetInformationOfBuildRequest GetInformationOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<IGetInformationOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumber, buildNumber));
        }

        public IGetInformationOfBuildRequest GetInformationOfLatestBuild(string projectKey, string planKey)
        {
            return _container.Resolve<IGetInformationOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumber, "latest"));
        }

        public IGetCommentsOfBuildRequest GetCommentsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<IGetCommentsOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumber, buildNumber));
        }

        public IAddCommentToBuildCommand AddCommentToBuild(string projectKey, string planKey, uint buildNumber, string comment)
        {
            return _container.Resolve<IAddCommentToBuildCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumber, buildNumber),
                new InjectProperty(RequestPropertyNames.Comment, comment));
        }

        public IGetLabelsOfBuildRequest GetLabelsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<IGetLabelsOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumber, buildNumber));
        }

        public IAddLabelToBuildCommand AddLabelToBuild(string projectKey, string planKey, uint buildNumber, string label)
        {
            return _container.Resolve<IAddLabelToBuildCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumber, buildNumber),
                new InjectProperty(RequestPropertyNames.Label, label));
        }

        public IDeleteLabelOfBuildCommand DeleteLabelOfBuild(string projectKey, string planKey, uint buildNumber, string label)
        {
            return _container.Resolve<IDeleteLabelOfBuildCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumber, buildNumber),
                new InjectProperty(RequestPropertyNames.Label, label));
        }
    }
}