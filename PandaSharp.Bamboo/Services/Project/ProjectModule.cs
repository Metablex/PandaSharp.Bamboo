using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Bamboo.Utils;

namespace PandaSharp.Bamboo.Services.Project
{
    internal sealed class ProjectModule : IPandaContextModule
    {
        public void RegisterModule(IPandaContainer container, PandaContainerContext context)
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
                .RequestRegistrationFor<IGetInformationOfRequest>()
                .LatestRequest<GetInformationOfRequest>()
                .Register(context);

            container.RegisterType<IGetInformationOfRequestAspect, GetInformationOfRequestAspect>();
            container.RegisterType<IGetAllProjectsParameterAspect, GetAllProjectsParameterAspect>();
            container.RegisterType<ICreateProjectCommandAspect, CreateProjectCommandAspect>();
            container.RegisterType<IProjectRequestBuilderFactory, ProjectRequestBuilderFactory>();
        }
    }
}