using PandaSharp.Bamboo.Rest.Contract;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;

namespace PandaSharp.Bamboo.Rest.Common
{
    internal sealed class BambooAuthentication : IBambooAuthentication
    {
        private IAuthenticator _authenticator;
        
        public IAuthenticator CreateAuthenticator()
        {
            return _authenticator;
        }

        public void UseBasic(string userName, string userPassword)
        {
            _authenticator = new HttpBasicAuthenticator(userName, userPassword);
        }

        public void UseOAuth(string consumerKey, string consumerSecret, string oAuthAccessToken, string oAuthTokenSecret)
        {
            _authenticator = OAuth1Authenticator.ForProtectedResource(
                consumerKey,
                consumerSecret,
                oAuthAccessToken,
                oAuthTokenSecret,
                OAuthSignatureMethod.RsaSha1);
        }
    }
}