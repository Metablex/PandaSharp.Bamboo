using PandaSharp.Rest.Contract;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace PandaSharp.Rest.Common
{
    internal sealed class RestFactory : IRestFactory
    {
        private readonly IBambooOptions _bambooOptions;
        private readonly IDeserializer _deserializer;

        public RestFactory(IBambooOptions bambooOptions, IDeserializer deserializer)
        {
            _bambooOptions = bambooOptions;
            _deserializer = deserializer;
        }

        public IRestClient CreateClient()
        {
            var client = new RestClient(_bambooOptions.BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(_bambooOptions.UserName, _bambooOptions.Password)
            };

            client.AddHandler("application/json", () => _deserializer);
            return client;
        }

        public IRestRequest CreateRequest(string resource, Method method)
        {
            return new RestRequest(resource, method);
        }
    }
}
