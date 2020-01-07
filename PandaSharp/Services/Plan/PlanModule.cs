using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Plan.Aspect;
using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Plan.Factory;
using PandaSharp.Services.Plan.Request;
using PandaSharp.Utils;

namespace PandaSharp.Services.Plan
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

            container.RegisterType<IBranchesOfPlanParameterAspect, BranchesOfPlanParameterAspect>();
            container.RegisterExpandStateParameterAspect<PlanExpandState>();
            container.RegisterExpandStateParameterAspect<PlansExpandState>();

            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
        }
    }
}
