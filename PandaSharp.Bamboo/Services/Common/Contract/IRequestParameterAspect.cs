using RestSharp;

namespace PandaSharp.Bamboo.Services.Common.Contract
{
    internal interface IRequestParameterAspect
    {
        void ApplyToRestRequest(IRestRequest restRequest);
    }
}