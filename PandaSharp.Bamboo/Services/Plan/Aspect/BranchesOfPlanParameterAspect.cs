using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal sealed class BranchesOfPlanParameterAspect : RequestParameterAspectBase, IBranchesOfPlanParameterAspect
    {
        public bool OnlyEnabledBranches { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest.AddParameter("enabledOnly", OnlyEnabledBranches);
        }
    }
}