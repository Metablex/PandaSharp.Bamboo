using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.IoC.Injections;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Project.Contract;

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

        public IGetInformationOfRequest GetInformationOf(string projectKey)
        {
            return _container.Resolve<IGetInformationOfRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey));
        }
    }
}