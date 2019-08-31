namespace PandaSharp.Services.Plan.Contract
{
    public interface IPlanRequestBuilderFactory
    {
        IAllPlansRequest AllPlans();

//        IBranchesOfPlanRequestBuilder GetBranchesOfPlan(string planKey);

//        IDetailsPlanBranchRequestBuilder GetDetailsOfPlanBranch(string planKey, string branchName);
    }
}
