using RestSharp;

namespace PandaSharp.Services.Common
{
    internal interface IRestClientProvider
    {
        IRestClient ProvideClient();
    }
}
