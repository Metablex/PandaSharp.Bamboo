using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Common.Aspect;
using PandaSharp.Utils;
using RestSharp;

namespace PandaSharp.Services.Build.Aspect
{
    internal sealed class BuildStateParameterAspect : RequestParameterAspectBase, IBuildStateParameterAspect
    {
        public BuildState? BuildState { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (BuildState.HasValue)
            {
                restRequest.AddParameterIfSet("buildstate", BuildState);
            }
            else
            {
                restRequest.AddParameter("includeAllStates", true);
            }
        }
    }
}