using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal sealed class BuildStateParameterAspect : RequestParameterAspectBase, IBuildStateParameterAspect
    {
        private BuildState? _buildState;

        public void SetBuildStateFilter(BuildState buildState)
        {
            _buildState = buildState;
        }

        public override void ApplyToRestRequest(RestRequest restRequest)
        {
            if (_buildState.HasValue)
            {
                restRequest.AddParameter("buildstate", _buildState.Value.GetEnumStringRepresentation());
            }
            else
            {
                restRequest.AddParameter("includeAllStates", true);
            }
        }
    }
}
