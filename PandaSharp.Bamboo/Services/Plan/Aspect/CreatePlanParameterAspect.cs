using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal sealed class CreatePlanParameterAspect : RequestParameterAspectBase, ICreatePlanParameterAspect
    {
        public string VcsBranch { get; set; }

        public bool? IsEnabled { get; set; }

        public bool? IsCleanupEnabled { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest
                .AddNotEncodedParameterIfSet("vcsBranch", VcsBranch)
                .AddParameterIfSet("enabled", IsEnabled)
                .AddParameterIfSet("cleanupEnabled", IsCleanupEnabled);
        }
    }
}