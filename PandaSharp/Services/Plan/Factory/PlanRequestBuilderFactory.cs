using PandaSharp.IoC.Contract;
using PandaSharp.IoC.Injections;
using PandaSharp.Services.Common.Request;
using PandaSharp.Services.Plan.Contract;

namespace PandaSharp.Services.Plan.Factory
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

        public IInformationOfRequest InformationOf(string projectKey, string planKey)
        {
            return _container.Resolve<IInformationOfRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }
    }
}
