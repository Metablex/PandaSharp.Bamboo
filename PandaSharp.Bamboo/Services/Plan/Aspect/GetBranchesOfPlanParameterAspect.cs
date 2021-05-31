using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal sealed class GetBranchesOfPlanParameterAspect : RequestParameterAspectBase, IGetBranchesOfPlanParameterAspect
    {
        public bool OnlyEnabledBranches { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (OnlyEnabledBranches)
            {
                restRequest.AddParameter("enabledOnly", null);
            }
        }
    }
}