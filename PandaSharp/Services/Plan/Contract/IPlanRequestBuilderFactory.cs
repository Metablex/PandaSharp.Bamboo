namespace PandaSharp.Services.Plan.Contract
{
    public interface IPlanRequestBuilderFactory
    {
        IAllPlansRequest AllPlans();

        IInformationOfPlanRequest InformationOf(string projectKey, string planKey);

        IBranchesOfPlanRequest BranchesOf(string projectKey, string planKey);
    }
}
