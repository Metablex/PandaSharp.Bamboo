using PandaSharp.Services.Plan.Contract;
using Unity;

namespace PandaSharp.Services.Plan.Factory
{
    internal sealed class PlanRequestBuilderFactory : IPlanRequestBuilderFactory
    {
        private readonly IUnityContainer _container;

        public PlanRequestBuilderFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IAllPlansRequest AllPlans()
        {
            return _container.Resolve<IAllPlansRequest>();
        }

        /*public IBranchesOfPlanRequestBuilder GetBranchesOfPlan(string planKey)
        {
            return _container.Resolve<IBranchesOfPlanRequestBuilder>();
        }

        public IDetailsPlanBranchRequestBuilder GetDetailsOfPlanBranch(string planKey, string branchName)
        {
            return _container.Resolve<IDetailsPlanBranchRequestBuilder>();
        }*/
    }
}
