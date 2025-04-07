using PandaSharp.Framework.IoC;
using PandaSharp.Framework.Utils;
using RestSharp.Authenticators.OAuth2;

namespace PandaSharp.Bamboo
{
    public static class BambooApiFactory
    {
        public static IBambooApi CreateWithBasicAuthentication(string baseUrl, string userName, string password)
        {
            var container = new PandaContainer();
            container.RegisterWithBasicAuthentication(baseUrl, userName, password);
            container.RegisterPandaModules();
            
            return container.Resolve<IBambooApi>();
        }

        public static IBambooApi CreateWithAccessTokenAuthentication(string baseUrl, string accesstoken)
        {
            var container = new PandaContainer();
            var authentication = new OAuth2AuthorizationRequestHeaderAuthenticator(
                accesstoken, "Bearer"
            );
            container.RegisterWithCustomAuthentication(baseUrl, authentication);
            container.RegisterPandaModules();

            return container.Resolve<IBambooApi>();
        }

        public static IBambooApi CreateWithOAuthAuthentication(
            string baseUrl,
            string consumerKey,
            string consumerSecret,
            string oAuthAccessToken,
            string oAuthTokenSecret)
        {
            var container = new PandaContainer();
            container.RegisterWithOAuthAuthentication(baseUrl, consumerKey, consumerSecret, oAuthAccessToken, oAuthTokenSecret);
            container.RegisterPandaModules();

            return container.Resolve<IBambooApi>();
        }
    }
}