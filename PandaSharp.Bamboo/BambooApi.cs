using System;
using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Framework.IoC;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Utils;

namespace PandaSharp.Bamboo
{
    public sealed class BambooApi
    {
        private readonly Lazy<IPandaContainer> _container;

        public IProjectRequestBuilderFactory ProjectRequest => _container.Value.Resolve<IProjectRequestBuilderFactory>();

        public IPlanRequestBuilderFactory PlanRequest => _container.Value.Resolve<IPlanRequestBuilderFactory>();

        public IBuildRequestBuilderFactory BuildRequest => _container.Value.Resolve<IBuildRequestBuilderFactory>();

        public IUsersRequestBuilderFactory UsersRequest => _container.Value.Resolve<IUsersRequestBuilderFactory>();

        public ISearchRequestBuilderFactory SearchRequest => _container.Value.Resolve<ISearchRequestBuilderFactory>();

        private BambooApi(string baseUrl, string userName, string password)
        {
            _container = new Lazy<IPandaContainer>(
                () =>
                {
                    var container = new PandaContainer();
                    container.RegisterWithBasicAuthentication(baseUrl, userName, password);
                    container.RegisterPandaModules(new BambooApiContext());

                    return container;
                });
        }

        private BambooApi(string baseUrl, string consumerKey, string consumerSecret, string oAuthAccessToken, string oAuthTokenSecret)
        {
            _container = new Lazy<IPandaContainer>(
                () =>
                {
                    var container = new PandaContainer();
                    container.RegisterWithOAuthAuthentication(baseUrl, consumerKey, consumerSecret, oAuthAccessToken, oAuthTokenSecret);
                    container.RegisterPandaModules(new BambooApiContext());

                    return container;
                });
        }

        public static BambooApi CreateWithBasicAuthentication(string baseUrl, string userName, string password)
        {
            return new BambooApi(baseUrl, userName, password);
        }

        public static BambooApi CreateWithOAuthAuthentication(
            string baseUrl,
            string consumerKey,
            string consumerSecret,
            string oAuthAccessToken,
            string oAuthTokenSecret)
        {
            return new BambooApi(baseUrl, consumerKey, consumerSecret, oAuthAccessToken, oAuthTokenSecret);
        }
    }
}
