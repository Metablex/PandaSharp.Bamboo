using RestSharp;

namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal interface IRequestParameterAspect
    {
        void ApplyToRestRequest(IRestRequest restRequest);
    }
}