using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Search.Contract;
using PandaSharp.Services.Users.Contract;
using PandaSharp.Utils;

namespace PandaSharp
{
    public sealed class BambooApi
    {
        private readonly IPandaContainer _container;

        public IPlanRequestBuilderFactory PlanRequest => _container.Resolve<IPlanRequestBuilderFactory>();

        public IBuildRequestBuilderFactory BuildRequest => _container.Resolve<IBuildRequestBuilderFactory>();

        public IUsersRequestBuilderFactory UsersRequest => _container.Resolve<IUsersRequestBuilderFactory>();

        public ISearchRequestBuilderFactory SearchRequest => _container.Resolve<ISearchRequestBuilderFactory>();

        public BambooApi(string baseUrl, string userName, string password)
        {
            _container = new PandaContainer();
            _container.RegisterPandaModules();

            LoginWithCredentials(baseUrl, userName, password);
        }

        private void LoginWithCredentials(string baseUrl, string userName, string password)
        {
            var options = _container.Resolve<IBambooOptions>();
            options.BaseUrl = baseUrl;
            options.UserName = userName;
            options.Password = password;
        }
    }
}
