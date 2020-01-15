using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal sealed class BuildStateParameterAspect : RequestParameterAspectBase, IBuildStateParameterAspect
    {
        public BuildState? BuildState { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (BuildState.HasValue)
            {
                restRequest.AddParameter("buildstate", BuildState);
            }
            else
            {
                restRequest.AddParameter("includeAllStates", true);
            }
        }
    }
}