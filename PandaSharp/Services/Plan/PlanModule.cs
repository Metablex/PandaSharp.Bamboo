using PandaSharp.Services.Plan.Request;
using PandaSharp.Services.Plan.Request.Builder;
using Unity;

namespace PandaSharp.Services.Plan
{
    internal static class PlanModule
    {
        public static void RegisterPlanModule(this IUnityContainer container)
        {
            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
            container.RegisterType<IAllPlansRequestBuilder, AllPlansRequestBuilder>();
        }
    }
}
