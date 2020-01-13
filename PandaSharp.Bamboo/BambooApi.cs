using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Utils;

namespace PandaSharp.Bamboo
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
            _container.RegisterPandaModules(() => LoginWithCredentials(baseUrl, userName, password));
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
