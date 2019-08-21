using RestSharp;

namespace PandaSharp.Rest.Contract
{
    internal interface IRestFactory
    {
        IRestClient CreateClient();

        IRestRequest CreateRequest(string resource, Method method);
    }
}
