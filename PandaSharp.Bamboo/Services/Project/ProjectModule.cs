using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Project
{
    internal sealed class ProjectModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IGetInformationOfProjectRequestAspect, GetInformationOfProjectRequestAspect>();
            container.RegisterType<IGetAllProjectsParameterAspect, GetAllProjectsParameterAspect>();
            container.RegisterType<ICreateProjectCommandAspect, CreateProjectCommandAspect>();
            container.RegisterType<IProjectRequestBuilderFactory, ProjectRequestBuilderFactory>();
        }
    }
}
