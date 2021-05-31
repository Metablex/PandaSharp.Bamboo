using System;
using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Framework.IoC;
using PandaSharp.Framework.IoC.Contract;

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
                () => PandaContainerFactory.CreateAndRegisterContainerWithCredentials(new BambooApiContext(), baseUrl, userName, password));
        }

        private BambooApi(string baseUrl, string consumerKey, string consumerSecret, string oAuthAccessToken, string oAuthTokenSecret)
        {
            _container = new Lazy<IPandaContainer>(
                () => PandaContainerFactory.CreateAndRegisterContainerWithOAuth(new BambooApiContext(), baseUrl, consumerKey, consumerSecret, oAuthAccessToken, oAuthTokenSecret));
        }

        public static BambooApi CreateWithBasicAuthentication(string baseUrl, string userName, string password)
        {
            return new(baseUrl, userName, password);
        }

        public static BambooApi CreateWithOAuthAuthentication(
            string baseUrl,
            string consumerKey,
            string consumerSecret,
            string oAuthAccessToken,
            string oAuthTokenSecret)
        {
            return new(baseUrl, consumerKey, consumerSecret, oAuthAccessToken, oAuthTokenSecret);
        }
    }
}
