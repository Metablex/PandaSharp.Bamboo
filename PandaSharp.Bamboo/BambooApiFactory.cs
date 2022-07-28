using PandaSharp.Framework.IoC;
using PandaSharp.Framework.Utils;

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