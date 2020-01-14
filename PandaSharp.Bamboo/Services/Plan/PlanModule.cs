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
                .RequestRegistrationFor<IAllPlansRequest>()
                .LatestRequest<AllPlansRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IInformationOfPlanRequest>()
                .LatestRequest<InformationOfPlanRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IBranchesOfPlanRequest>()
                .LatestRequest<BranchesOfPlanRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IArtifactsOfPlanRequest>()
                .LatestRequest<ArtifactsOfPlanRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IEnableDisablePlanCommand>()
                .LatestRequest<EnableDisablePlanCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<IDeletePlanCommand>()
                .LatestRequest<DeletePlanCommand>()
                .Register(context);

            container.RegisterType<IBranchesOfPlanParameterAspect, BranchesOfPlanParameterAspect>();
            container.RegisterExpandStateParameterAspect<PlanExpandState>();
            container.RegisterExpandStateParameterAspect<PlansExpandState>();

            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
        }
    }
}
