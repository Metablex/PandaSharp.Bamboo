using PandaSharp.Rest;
using PandaSharp.Services;
using PandaSharp.Services.Build;
using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Plan;
using PandaSharp.Services.Plan.Contract;
using Unity;

namespace PandaSharp
{
    public sealed class BambooApi
    {
        private readonly IUnityContainer _container;

        public IPlanRequestBuilderFactory PlanRequest => _container.Resolve<IPlanRequestBuilderFactory>();
        
        public IBuildRequestBuilderFactory BuildRequest => _container.Resolve<IBuildRequestBuilderFactory>();

        public BambooApi(string baseUrl, string userName, string password)
        {
            _container = new UnityContainer();

            _container.RegisterRestModule(baseUrl, userName, password);
            _container.RegisterServicesModule();
            _container.RegisterPlanModule();
            _container.RegisterBuildModule();
        }
    }
}
