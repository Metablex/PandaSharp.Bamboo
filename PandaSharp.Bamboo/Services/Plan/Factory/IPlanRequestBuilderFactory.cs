using PandaSharp.Bamboo.Services.Plan.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Factory
{
    public interface IPlanRequestBuilderFactory
    {
        IAllPlansRequest AllPlans();

        IInformationOfPlanRequest InformationOf(string projectKey, string planKey);

        IBranchesOfPlanRequest BranchesOf(string projectKey, string planKey);

        IArtifactsOfPlanRequest ArtifactsOf(string projectKey, string planKey);

        ILabelsOfPlanRequest LabelsOf(string projectKey, string planKey);

        IVcsBranchesOfPlanRequest VcsBranchesOf(string projectKey, string planKey);

        ILabelsOfPlanRequest AddLabelToPlan(string projectKey, string planKey, string labelName);

        IDeleteLabelOfPlanCommand DeleteLabelOfPlan(string projectKey, string planKey, string labelName);

        IEnableDisablePlanCommand EnablePlan(string projectKey, string planKey);

        IEnableDisablePlanCommand DisablePlan(string projectKey, string planKey);

        IDeletePlanCommand DeletePlan(string projectKey, string planKey);

        ICreatePlanCommand CreateBranch(string projectKey, string planKey, string branchName);

        IFavouritePlanCommand FavouritePlan(string projectKey, string planKey);

        IFavouritePlanCommand UnfavouritePlan(string projectKey, string planKey);
    }
}
