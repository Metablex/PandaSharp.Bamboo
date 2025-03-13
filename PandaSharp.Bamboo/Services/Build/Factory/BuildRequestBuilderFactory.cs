using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Common;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;

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
            var restFactory = CreateRestFactory();
            var context = new RestCommunicationContext();

            return new GetBuildsOfPlanRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetBuildsOfPlanRequest GetBuildsOfPlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);

            return new GetBuildsOfPlanRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetInformationOfBuildRequest GetInformationOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.BuildNumber, buildNumber);

            return new GetInformationOfBuildRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetInformationOfBuildRequest GetInformationOfLatestBuild(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.BuildNumber, "latest");

            return new GetInformationOfBuildRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetCommentsOfBuildRequest GetCommentsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.BuildNumber, buildNumber);

            return new GetCommentsOfBuildRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IAddCommentToBuildCommand AddCommentToBuild(string projectKey, string planKey, uint buildNumber, string comment)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.BuildNumber, buildNumber);
            context.AddContextParameter(RequestPropertyNames.Comment, comment);

            return new AddCommentToBuildCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public IGetLabelsOfBuildRequest GetLabelsOfBuild(string projectKey, string planKey, uint buildNumber)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.BuildNumber, buildNumber);

            return new GetLabelsOfBuildRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IAddLabelToBuildCommand AddLabelToBuild(string projectKey, string planKey, uint buildNumber, string label)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.BuildNumber, buildNumber);
            context.AddContextParameter(RequestPropertyNames.Label, label);

            return new AddLabelToBuildCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public IDeleteLabelOfBuildCommand DeleteLabelOfBuild(string projectKey, string planKey, uint buildNumber, string label)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.BuildNumber, buildNumber);
            context.AddContextParameter(RequestPropertyNames.Label, label);

            return new DeleteLabelOfBuildCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        private IRestFactory CreateRestFactory()
        {
            return new RestFactory(_container.Resolve<IRestOptions>(), JsonRestSerializer.Default);
        }
    }
}
