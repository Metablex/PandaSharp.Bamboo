using PandaSharp.Rest.Contract;
using RestSharp;

namespace PandaSharp.Services.Common
{
    internal abstract class RequestBase<T> : IRestClientProvider, IRequestBuilderBase<T>
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

        public IRestClient ProvideClient()
        {
            return _restFactory.CreateClient();
        }

        public abstract IRestRequest Build();
    }
}
