using PandaSharp.Rest.Contract;
using RestSharp;
using RestSharp.Authenticators;

namespace PandaSharp.Rest.Model
{
    internal class RestFactory : IRestFactory
    {
        private readonly IBambooOptions _bambooOptions;

        public RestFactory(IBambooOptions bambooOptions)
        {
            _bambooOptions = bambooOptions;
        }

        public IRestClient CreateClient()
        {
            return new RestClient(_bambooOptions.BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(_bambooOptions.UserName, _bambooOptions.Password)
            };
        }

        public IRestRequest CreateRequest(string resource, Method method)
        {
            return new RestRequest(resource, method);
        }
    }
}
