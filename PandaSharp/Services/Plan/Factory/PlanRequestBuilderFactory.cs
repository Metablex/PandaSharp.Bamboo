using PandaSharp.Services.Common.Request;
using PandaSharp.Services.Plan.Contract;
using Unity;
using Unity.Resolution;

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

        public IInformationOfRequest InformationOf(string planKey)
        {
            return _container.Resolve<IInformationOfRequest>(
                new PropertyOverride(RequestPropertyNames.PlanKeyName, planKey));
        }
    }
}
