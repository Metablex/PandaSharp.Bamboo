using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal sealed class CreatePlanParameterAspect : RequestParameterAspectBase, ICreatePlanParameterAspect
    {
        private string _vcsBranch;
        private bool? _isEnabled;
        private bool? _isCleanupEnabled;

        public void SetVcsBranchFilter(string vcsBranch)
        {
            _vcsBranch = vcsBranch;
        }

        public void SetIsEnabledFilter(bool isEnabled)
        {
            _isEnabled = isEnabled;
        }

        public void SetIsCleanupEnabledFilter(bool isCleanupEnabled)
        {
            _isCleanupEnabled = isCleanupEnabled;
        }

        public override void ApplyToRestRequest(RestRequest restRequest)
        {
            restRequest
                .AddNotEncodedParameterIfSet("vcsBranch", _vcsBranch)
                .AddParameterIfSet("enabled", _isEnabled)
                .AddParameterIfSet("cleanupEnabled", _isCleanupEnabled);
        }
    }
}
