using PandaSharp.Rest.Contract;
using RestSharp;

namespace PandaSharp.Services.Common
{
    internal abstract class RequestBase
    {
        private readonly IRestFactory _restFactory;

        protected RequestBase(IRestFactory restClientFactory)
        {
            _restFactory = restClientFactory;
        }

        protected IRestRequest CreateEmptyRequest(string resource, Method method)
        {
            return _restFactory.CreateRequest(resource, method);
        }

        protected T Execute<T>(IRestRequest restRequest)
            where T : class, new()
        {
            var client = _restFactory.CreateClient();
            var response = client.Execute<T>(restRequest);

            return response.Data;
        }
    }
}
