using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Plan.Contract;
using RestSharp;

namespace PandaSharp.Services.Plan.Aspect
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