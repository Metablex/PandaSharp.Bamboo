using PandaSharp.Bamboo.Rest.Contract;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;

namespace PandaSharp.Bamboo.Rest.Common
{
    internal sealed class RestFactory : IRestFactory
    {
        private readonly IBambooOptions _bambooOptions;
        private readonly IRestSerializer _serializer;

        public RestFactory(IBambooOptions bambooOptions, IRestSerializer serializer)
        {
            _bambooOptions = bambooOptions;
            _serializer = serializer;
        }

        public IRestClient CreateClient()
        {
            var client = new RestClient(_bambooOptions.BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(_bambooOptions.UserName, _bambooOptions.Password)
            };

            client.UseSerializer(() => _serializer);
            return client;
        }

        public IRestRequest CreateRequest(string resource, Method method)
        {
            return new RestRequest(resource, method);
        }
    }
}
