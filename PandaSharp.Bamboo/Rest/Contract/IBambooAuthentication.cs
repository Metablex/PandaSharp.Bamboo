using RestSharp.Authenticators;

namespace PandaSharp.Bamboo.Rest.Contract
{
    internal interface IBambooAuthentication
    {
        IAuthenticator CreateAuthenticator();

        void UseBasic(string userName, string userPassword);

        void UseOAuth(
            string consumerKey,
            string consumerSecret,
            string oAuthAccessToken,
            string oAuthTokenSecret);
    }
}