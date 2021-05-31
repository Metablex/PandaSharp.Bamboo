using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.IoC.Injections;

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
            return _container.Resolve<IGetAllProjectsRequest>();
        }

        public ICreateProjectCommand CreateProject(string projectKey, string projectName)
        {
            return _container.Resolve<ICreateProjectCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.ProjectName, projectName));
        }

        public IDeleteProjectCommand DeleteProject(string projectKey)
        {
            return _container.Resolve<IDeleteProjectCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey));
        }

        public IGetInformationOfProjectRequest GetInformationOfProject(string projectKey)
        {
            return _container.Resolve<IGetInformationOfProjectRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey));
        }
    }
}