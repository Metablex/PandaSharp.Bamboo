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

        public IBuildListRequest AllBuilds()
        {
            return _container.Resolve<IBuildListRequest>();
        }

        public IBuildListRequest BuildsOfPlan(string projectKey, string planKey)
        {
            return _container.Resolve<IBuildListRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }

        public IBuildRequest InformationOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<IBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, buildNumber.ToString()));
        }

        public IBuildRequest InformationOfLatestBuild(string projectKey, string planKey)
        {
            return _container.Resolve<IBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, "latest"));
        }

        public ICommentsOfBuildRequest CommentsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<ICommentsOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, buildNumber));
        }

        public ILabelsOfBuildRequest LabelsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<ILabelsOfBuildRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BuildNumberName, buildNumber));
        }
    }
}