using PandaSharp.Services.Plan.Request.Builder;

namespace PandaSharp.Services.Plan.Request
{
    public interface IPlanRequestBuilderFactory
    {
        IAllPlansRequestBuilder GetAllPlans();

        IBranchesOfPlanRequestBuilder GetBranchesOfPlan(string planKey);

        IDetailsPlanBranchRequestBuilder GetDetailsOfPlanBranch(string planKey, string branchName);
    }
}
