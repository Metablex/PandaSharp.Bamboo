using System;
using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Bamboo.Utils;

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
            _container = new Lazy<IPandaContainer>(() => CreateAndRegisterContainerWithCredentials(baseUrl, userName, password));
        }

        private BambooApi(string baseUrl, string consumerKey, string consumerSecret, string oAuthAccessToken, string oAuthTokenSecret)
        {
            _container = new Lazy<IPandaContainer>(() => CreateAndRegisterContainerWithOAuth(baseUrl, consumerKey, consumerSecret, oAuthAccessToken, oAuthTokenSecret));
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

        private static IPandaContainer CreateAndRegisterContainerWithCredentials(string baseUrl, string userName, string password)
        {
            var container = new PandaContainer();
            container.RegisterPandaModules(() => AuthenticateWithCredentials(container, baseUrl, userName, password));

            return container;
        }

        private static IPandaContainer CreateAndRegisterContainerWithOAuth(
            string baseUrl,  
            string consumerKey, 
            string consumerSecret, 
            string oAuthAccessToken,
            string oAuthTokenSecret)
        {
            var container = new PandaContainer();
            container.RegisterPandaModules(() => AuthenticateWithOAuth(container, baseUrl, consumerKey, consumerSecret, oAuthAccessToken, oAuthTokenSecret));

            return container;
        }
        
        private static void AuthenticateWithCredentials(IPandaContainer container, string baseUrl, string userName, string password)
        {
            var options = container.Resolve<IBambooOptions>();
            options.BaseUrl = baseUrl;
            options.Authentication.UseBasic(userName, password);
        }
        
        private static void AuthenticateWithOAuth(
            IPandaContainer container, 
            string baseUrl, 
            string consumerKey, 
            string consumerSecret, 
            string oAuthAccessToken,
            string oAuthTokenSecret)
        {
            var options = container.Resolve<IBambooOptions>();
            options.BaseUrl = baseUrl;
            options.Authentication.UseOAuth(consumerKey, consumerSecret, oAuthAccessToken, oAuthTokenSecret);
        }
    }
}
