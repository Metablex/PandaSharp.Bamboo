using PandaSharp.Services.Plan.Aspect;
using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Plan.Factory;
using PandaSharp.Services.Plan.Request;
using Unity;

namespace PandaSharp.Services.Plan
{
    internal static class PlanModule
    {
        public static void RegisterPlanModule(this IUnityContainer container)
        {
            container.RegisterType<IAllPlansRequest, AllPlansRequest>();
            container.RegisterType<IInformationOfRequest, InformationOfRequest>();

            container.RegisterType<IPlansExpandStateParameterAspect, PlansExpandStateParameterAspect>();
            container.RegisterType<IPlanExpandStateParameterAspect, PlanExpandStateParameterAspect>();

            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
        }
    }
}
