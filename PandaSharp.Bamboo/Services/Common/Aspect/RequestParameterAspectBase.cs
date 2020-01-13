using RestSharp;

namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal abstract class RequestParameterAspectBase : IRequestParameterAspect
    {
        public abstract void ApplyToRestRequest(IRestRequest restRequest);
    }
}