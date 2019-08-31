using PandaSharp.Services.Plan.Aspect;
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
            container.RegisterRequest<IAllPlansRequest, AllPlansRequest>();
            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
            container.RegisterParameterAspect<PlansExpandStateParameterAspect>();
        }
    }
}
