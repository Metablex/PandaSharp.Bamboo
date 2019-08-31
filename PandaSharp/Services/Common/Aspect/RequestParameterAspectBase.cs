using PandaSharp.Services.Common.Contract;
using RestSharp;

namespace PandaSharp.Services.Common.Aspect
{
    internal abstract class RequestParameterAspectBase : IRequestParameterAspect
    {
        public abstract void ApplyToRestRequest(IRestRequest restRequest);
    }
}