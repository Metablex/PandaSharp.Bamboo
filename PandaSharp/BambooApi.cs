using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Rest;
using PandaSharp.Services;
using PandaSharp.Services.Build;
using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Plan;
using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Users;
using PandaSharp.Services.Users.Contract;

namespace PandaSharp
{
    public sealed class BambooApi
    {
        private readonly IPandaContainer _container;

        public IPlanRequestBuilderFactory PlanRequest => _container.Resolve<IPlanRequestBuilderFactory>();

        public IBuildRequestBuilderFactory BuildRequest => _container.Resolve<IBuildRequestBuilderFactory>();

        public IUsersRequestBuilderFactory UsersRequest => _container.Resolve<IUsersRequestBuilderFactory>();

        public BambooApi(string baseUrl, string userName, string password)
        {
            _container = new PandaContainer();

            _container.RegisterRestModule(baseUrl, userName, password);
            _container.RegisterServicesModule();
            _container.RegisterPlanModule();
            _container.RegisterBuildModule();
            _container.RegisterUsersModule();
        }
    }
}
