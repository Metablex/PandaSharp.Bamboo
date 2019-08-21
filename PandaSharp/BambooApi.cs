using PandaSharp.Rest;
using PandaSharp.Services.Plan;
using PandaSharp.Services.Plan.Request;
using Unity;

namespace PandaSharp
{
    public class BambooApi
    {
        private IUnityContainer _container;

        public IPlanRequestBuilderFactory PlanRequest => _container.Resolve<IPlanRequestBuilderFactory>();

        public BambooApi(string baseUrl, string userName, string password)
        {
            _container = new UnityContainer();

            _container.RegisterRestModule(baseUrl, userName, password);
            _container.RegisterPlanModule();
        }
    }
}
