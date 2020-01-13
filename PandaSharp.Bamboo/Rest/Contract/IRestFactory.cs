using RestSharp;

namespace PandaSharp.Bamboo.Rest.Contract
{
    internal interface IRestFactory
    {
        IRestClient CreateClient();

        IRestRequest CreateRequest(string resource, Method method);
    }
}
