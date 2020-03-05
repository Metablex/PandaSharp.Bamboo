using System;
using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Bamboo.Utils;

namespace PandaSharp.Bamboo
{
    public sealed class BambooApi
    {
        private readonly Lazy<IPandaContainer> _container;

        public IPlanRequestBuilderFactory PlanRequest => _container.Value.Resolve<IPlanRequestBuilderFactory>();

        public IBuildRequestBuilderFactory BuildRequest => _container.Value.Resolve<IBuildRequestBuilderFactory>();

        public IUsersRequestBuilderFactory UsersRequest => _container.Value.Resolve<IUsersRequestBuilderFactory>();

        public ISearchRequestBuilderFactory SearchRequest => _container.Value.Resolve<ISearchRequestBuilderFactory>();

        public BambooApi(string baseUrl, string userName, string password)
        {
            _container = new Lazy<IPandaContainer>(() => CreateAndRegisterContainer(baseUrl, userName, password));
        }

        private static IPandaContainer CreateAndRegisterContainer(string baseUrl, string userName, string password)
        {
            var container = new PandaContainer();
            container.RegisterPandaModules(() => LoginWithCredentials(container, baseUrl, userName, password));

            return container;
        }

        private static void LoginWithCredentials(IPandaContainer container, string baseUrl, string userName, string password)
        {
            var options = container.Resolve<IBambooOptions>();
            options.BaseUrl = baseUrl;
            options.UserName = userName;
            options.Password = password;
        }
    }
}
