using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Plan.Aspect;
using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Plan.Factory;
using PandaSharp.Services.Plan.Request;
using PandaSharp.Utils;

namespace PandaSharp.Services.Plan
{
    internal sealed class PlanModule : PandaModuleBase
    {
        public override void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IAllPlansRequest, AllPlansRequest>();
            container.RegisterType<IInformationOfPlanRequest, InformationOfPlanRequest>();
            container.RegisterType<IBranchesOfPlanRequest, BranchesOfPlanRequest>();

            container.RegisterType<IBranchesOfPlanParameterAspect, BranchesOfPlanParameterAspect>();
            container.RegisterExpandStateParameterAspect<PlanExpandState>();
            container.RegisterExpandStateParameterAspect<PlansExpandState>();

            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
        }
    }
}
