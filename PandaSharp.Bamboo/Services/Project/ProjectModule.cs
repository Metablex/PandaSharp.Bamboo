using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Project
{
    internal sealed class ProjectModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IGetAllProjectsRequest, GetAllProjectsRequest>();
            container.RegisterType<ICreateProjectCommand, CreateProjectCommand>();
            container.RegisterType<IDeleteProjectCommand, DeleteProjectCommand>();
            container.RegisterType<IGetInformationOfProjectRequest, GetInformationOfProjectRequest>();
            container.RegisterType<IGetInformationOfProjectRequestAspect, GetInformationOfProjectRequestAspect>();
            container.RegisterType<IGetAllProjectsParameterAspect, GetAllProjectsParameterAspect>();
            container.RegisterType<ICreateProjectCommandAspect, CreateProjectCommandAspect>();
            container.RegisterType<IProjectRequestBuilderFactory, ProjectRequestBuilderFactory>();
        }
    }
}