using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Utils;

namespace PandaSharp.Bamboo.Services.Plan
{
    internal sealed class PlanModule : IPandaContextModule
    {
        public void RegisterModule(IPandaContainer container, IPandaContainerContext context)
        {
            container
                .RequestRegistrationFor<IGetAllPlansRequest>()
                .LatestRequest<GetAllPlansRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IGetInformationOfPlanRequest>()
                .LatestRequest<GetInformationOfPlanRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IGetBranchesOfPlanRequest>()
                .LatestRequest<GetBranchesOfPlanRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IGetArtifactsOfPlanRequest>()
                .LatestRequest<GetArtifactsOfPlanRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IEnableDisablePlanCommand>()
                .LatestRequest<EnableDisablePlanCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<IDeletePlanCommand>()
                .LatestRequest<DeletePlanCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<ICreatePlanCommand>()
                .LatestRequest<CreatePlanCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<IGetLabelsOfPlanRequest>()
                .LatestRequest<GetLabelsOfPlanRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IAddLabelToPlanCommand>()
                .LatestRequest<AddLabelToPlanCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<IDeleteLabelOfPlanCommand>()
                .LatestRequest<DeleteLabelOfPlanCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<IGetVcsBranchesOfPlanRequest>()
                .LatestRequest<GetVcsBranchesOfPlanRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IFavouritePlanCommand>()
                .LatestRequest<FavouritePlanCommand>()
                .Register(context);

            container.RegisterType<IGetBranchesOfPlanParameterAspect, GetBranchesOfPlanParameterAspect>();
            container.RegisterType<ICreatePlanParameterAspect, CreatePlanParameterAspect>();
            container.RegisterType<IGetAllPlansParameterAspect, GetAllPlansParameterAspect>();
            container.RegisterType<IGetInformationOfPlanParameterAspect, GetInformationOfPlanParameterAspect>();

            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
        }
    }
}
