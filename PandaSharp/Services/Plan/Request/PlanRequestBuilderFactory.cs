using PandaSharp.Services.Plan.Request.Builder;
using Unity;

namespace PandaSharp.Services.Plan.Request
{
    internal class PlanRequestBuilderFactory : IPlanRequestBuilderFactory
    {
        private readonly IUnityContainer _container;

        public PlanRequestBuilderFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IAllPlansRequestBuilder GetAllPlans()
        {
            return _container.Resolve<IAllPlansRequestBuilder>();
        }

        public IBranchesOfPlanRequestBuilder GetBranchesOfPlan(string planKey)
        {
            return _container.Resolve<IBranchesOfPlanRequestBuilder>();
        }

        public IDetailsPlanBranchRequestBuilder GetDetailsOfPlanBranch(string planKey, string branchName)
        {
            return _container.Resolve<IDetailsPlanBranchRequestBuilder>();
        }
    }
}
