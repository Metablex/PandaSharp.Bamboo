using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.IoC.Injections;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Plan.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Factory
{
    internal sealed class PlanRequestBuilderFactory : IPlanRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public PlanRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IAllPlansRequest AllPlans()
        {
            return _container.Resolve<IAllPlansRequest>();
        }

        public IInformationOfPlanRequest InformationOf(string projectKey, string planKey)
        {
            return _container.Resolve<IInformationOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }

        public IBranchesOfPlanRequest BranchesOf(string projectKey, string planKey)
        {
            return _container.Resolve<IBranchesOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }
    }
}
