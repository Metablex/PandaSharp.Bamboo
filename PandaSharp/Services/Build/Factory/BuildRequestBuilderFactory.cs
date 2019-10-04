using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Common.Request;
using Unity;
using Unity.Resolution;

namespace PandaSharp.Services.Build.Factory
{
    internal sealed class BuildRequestBuilderFactory : IBuildRequestBuilderFactory
    {
        private readonly IUnityContainer _container;

        public BuildRequestBuilderFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IBuildsRequest AllBuilds()
        {
            return _container.Resolve<IBuildsRequest>(
                new PropertyOverride(RequestPropertyNames.ProjectKeyName, null),
                new PropertyOverride(RequestPropertyNames.PlanKeyName, null));
        }

        public IBuildsRequest BuildsOfPlan(string projectKey, string planKey)
        {
            return _container.Resolve<IBuildsRequest>(
                new PropertyOverride(RequestPropertyNames.ProjectKeyName, projectKey),
                new PropertyOverride(RequestPropertyNames.PlanKeyName, planKey));
        }

        public IBuildRequest InformationOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<IBuildRequest>(
                new PropertyOverride(RequestPropertyNames.ProjectKeyName, projectKey),
                new PropertyOverride(RequestPropertyNames.PlanKeyName, planKey),
                new PropertyOverride(RequestPropertyNames.BuildNumberName, buildNumber.ToString()));
        }

        public IBuildRequest InformationOfLatestBuild(string projectKey, string planKey)
        {
            return _container.Resolve<IBuildRequest>(
                new PropertyOverride(RequestPropertyNames.ProjectKeyName, projectKey),
                new PropertyOverride(RequestPropertyNames.PlanKeyName, planKey),
                new PropertyOverride(RequestPropertyNames.BuildNumberName, "latest"));
        }

        public ICommentsOfBuildRequest CommentsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<ICommentsOfBuildRequest>(
                new PropertyOverride(RequestPropertyNames.PlanKeyName, planKey),
                new PropertyOverride(RequestPropertyNames.BuildNumberName, buildNumber));
        }

        public ILabelsOfBuildRequest LabelsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            return _container.Resolve<ILabelsOfBuildRequest>(
                new PropertyOverride(RequestPropertyNames.PlanKeyName, planKey),
                new PropertyOverride(RequestPropertyNames.BuildNumberName, buildNumber));
        }
    }
}