using PandaSharp.IoC.Contract;
using PandaSharp.IoC.Injections;
using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Common.Request;

namespace PandaSharp.Services.Build.Factory
{
    internal sealed class BuildRequestBuilderFactory : IBuildRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public BuildRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IBuildsRequest AllBuilds()
        {
            return _container.Resolve<IBuildsRequest>();
        }

        public IBuildsRequest BuildsOfPlan(string projectKey, string planKey)
        {
            return _container.Resolve<IBuildsRequest>(
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