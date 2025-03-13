using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Plan
{
    internal sealed class PlanModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IGetBranchesOfPlanParameterAspect, GetBranchesOfPlanParameterAspect>();
            container.RegisterType<ICreatePlanParameterAspect, CreatePlanParameterAspect>();
            container.RegisterType<IGetAllPlansParameterAspect, GetAllPlansParameterAspect>();
            container.RegisterType<IGetInformationOfPlanParameterAspect, GetInformationOfPlanParameterAspect>();
            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
        }
    }
}
