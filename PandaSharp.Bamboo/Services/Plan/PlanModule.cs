using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Services.Plan.Types;
using PandaSharp.Bamboo.Utils;

namespace PandaSharp.Bamboo.Services.Plan
{
    internal sealed class PlanModule : PandaContextModuleBase
    {
        public override void RegisterModule(IPandaContainer container, PandaContainerContext context)
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

            container.RegisterType<IBranchesOfPlanParameterAspect, BranchesOfPlanParameterAspect>();
            container.RegisterType<ICreatePlanParameterAspect, CreatePlanParameterAspect>();
            container.RegisterExpandStateParameterAspect<PlanExpandState>();
            container.RegisterExpandStateParameterAspect<PlansExpandState>();

            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
        }
    }
}
