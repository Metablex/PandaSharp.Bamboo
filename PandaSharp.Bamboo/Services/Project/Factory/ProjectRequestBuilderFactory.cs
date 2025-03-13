using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Common;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;

namespace PandaSharp.Bamboo.Services.Project.Factory
{
    internal sealed class ProjectRequestBuilderFactory : IProjectRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public ProjectRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IGetAllProjectsRequest GetAllProjects()
        {
            var restFactory = CreateRestFactory();

            return new GetAllProjectsRequest(
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public ICreateProjectCommand CreateProject(string projectKey, string projectName)
        {
            var restFactory = CreateRestFactory();

            return new CreateProjectCommand(
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>())
            {
                ProjectKey = projectKey,
                ProjectName = projectName
            };
        }

        public IDeleteProjectCommand DeleteProject(string projectKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);

            return new DeleteProjectCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public IGetInformationOfProjectRequest GetInformationOfProject(string projectKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);

            return new GetInformationOfProjectRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        private IRestFactory CreateRestFactory()
        {
            return new RestFactory(_container.Resolve<IRestOptions>(), JsonRestSerializer.Default);
        }
    }
}
