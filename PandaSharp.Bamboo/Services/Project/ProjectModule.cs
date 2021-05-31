using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Utils;

namespace PandaSharp.Bamboo.Services.Project
{
    internal sealed class ProjectModule : IPandaContextModule
    {
        public void RegisterModule(IPandaContainer container, IPandaContainerContext context)
        {
            container
                .RequestRegistrationFor<IGetAllProjectsRequest>()
                .LatestRequest<GetAllProjectsRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<ICreateProjectCommand>()
                .LatestRequest<CreateProjectCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<IDeleteProjectCommand>()
                .LatestRequest<DeleteProjectCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<IGetInformationOfProjectRequest>()
                .LatestRequest<GetInformationOfProjectRequest>()
                .Register(context);

            container.RegisterType<IGetInformationOfProjectRequestAspect, GetInformationOfProjectRequestAspect>();
            container.RegisterType<IGetAllProjectsParameterAspect, GetAllProjectsParameterAspect>();
            container.RegisterType<ICreateProjectCommandAspect, CreateProjectCommandAspect>();
            container.RegisterType<IProjectRequestBuilderFactory, ProjectRequestBuilderFactory>();
        }
    }
}