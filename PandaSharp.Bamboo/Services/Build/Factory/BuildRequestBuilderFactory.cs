using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.IoC.Injections;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Common.Types;

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
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }

        public IGetInformationOfBuildRequest GetInformationOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<IGetInformationOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, buildNumber));
        }

        public IGetInformationOfBuildRequest GetInformationOfLatestBuild(string projectKey, string planKey)
        {
            return _container.Resolve<IGetInformationOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, "latest"));
        }

        public IGetCommentsOfBuildRequest GetCommentsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<IGetCommentsOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, buildNumber));
        }

        public IAddCommentToBuildCommand AddCommentToBuild(string projectKey, string planKey, uint buildNumber, string comment)
        {
            return _container.Resolve<IAddCommentToBuildCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, buildNumber),
                new InjectProperty(RequestPropertyNames.Comment, comment));
        }

        public IGetLabelsOfBuildRequest GetLabelsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<IGetLabelsOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, buildNumber));
        }

        public IAddLabelToBuildCommand AddLabelToBuild(string projectKey, string planKey, uint buildNumber, string label)
        {
            return _container.Resolve<IAddLabelToBuildCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, buildNumber),
                new InjectProperty(RequestPropertyNames.LabelName, label));
        }

        public IDeleteLabelOfBuildCommand DeleteLabelOfBuild(string projectKey, string planKey, uint buildNumber, string label)
        {
            return _container.Resolve<IDeleteLabelOfBuildCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, buildNumber),
                new InjectProperty(RequestPropertyNames.LabelName, label));
        }
    }
}