using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal sealed class GetBranchesOfPlanParameterAspect : RequestParameterAspectBase, IGetBranchesOfPlanParameterAspect
    {
        private bool _onlyEnabledBranches;

        public void SetOnlyEnabledBranchesFilter(bool onlyEnabledBranches)
        {
            _onlyEnabledBranches = onlyEnabledBranches;
        }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (_onlyEnabledBranches)
            {
                restRequest.AddParameter("enabledOnly", true);
            }
        }
    }
}