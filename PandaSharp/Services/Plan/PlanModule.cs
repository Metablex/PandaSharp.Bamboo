using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Plan.Factory;
using PandaSharp.Services.Plan.Request;
using PandaSharp.Utils;
using Unity;

namespace PandaSharp.Services.Plan
{
    internal static class PlanModule
    {
        public static void RegisterPlanModule(this IUnityContainer container)
        {
            container.RegisterType<IAllPlansRequest, AllPlansRequest>();
            container.RegisterType<IInformationOfRequest, InformationOfRequest>();

            container.RegisterExpandStateParameterAspect<PlanExpandState>();
            container.RegisterExpandStateParameterAspect<PlansExpandState>();

            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
        }
    }
}
