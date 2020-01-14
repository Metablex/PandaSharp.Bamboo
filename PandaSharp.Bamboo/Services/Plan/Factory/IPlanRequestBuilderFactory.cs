using PandaSharp.Bamboo.Services.Plan.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Factory
{
    public interface IPlanRequestBuilderFactory
    {
        IAllPlansRequest AllPlans();

        IInformationOfPlanRequest InformationOf(string projectKey, string planKey);

        IBranchesOfPlanRequest BranchesOf(string projectKey, string planKey);

        IArtifactsOfPlanRequest ArtifactsOf(string projectKey, string planKey);

        IEnableDisablePlanCommand EnablePlan(string projectKey, string planKey);

        IEnableDisablePlanCommand DisablePlan(string projectKey, string planKey);

        IDeletePlanCommand DeletePlan(string projectKey, string planKey);
    }
}
