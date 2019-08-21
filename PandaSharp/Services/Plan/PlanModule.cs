using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Plan.Model;
using Unity;

namespace PandaSharp.Services.Plan
{
    internal static class PlanModule
    {
        public static void RegisterPlanModule(this IUnityContainer container)
        {
            container.RegisterType<IAllPlansRequest, AllPlansRequest>();
        }
    }
}
