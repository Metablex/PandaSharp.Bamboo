using RestSharp;

namespace PandaSharp.Services.Common.Contract
{
    internal interface IRequestParameterAspect
    {
        void ApplyToRestRequest(IRestRequest restRequest);
    }
}