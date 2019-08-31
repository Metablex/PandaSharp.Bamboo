using RestSharp;

namespace PandaSharp.Services.Common.Contract
{
    internal interface IRestClientProvider
    {
        IRestClient ProvideClient();
    }
}
