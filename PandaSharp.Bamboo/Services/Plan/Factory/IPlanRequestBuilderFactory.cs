﻿using PandaSharp.Bamboo.Services.Plan.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Factory
{
    public interface IPlanRequestBuilderFactory
    {
        IGetAllPlansRequest GetAllPlans();

        IGetInformationOfPlanRequest GetInformationOfPlan(string projectKey, string planKey);

        IGetBranchesOfPlanRequest GetBranchesOfPlan(string projectKey, string planKey);

        IGetArtifactsOfPlanRequest GetArtifactsOfPlan(string projectKey, string planKey);

        IGetLabelsOfPlanRequest GetLabelsOfPlan(string projectKey, string planKey);

        IGetVcsBranchesOfPlanRequest GetVcsBranchesOfPlan(string projectKey, string planKey);

        IAddLabelToPlanCommand AddLabelToPlan(string projectKey, string planKey, string labelName);

        IDeleteLabelOfPlanCommand DeleteLabelOfPlan(string projectKey, string planKey, string labelName);

        IEnableDisablePlanCommand EnablePlan(string projectKey, string planKey);

        IEnableDisablePlanCommand DisablePlan(string projectKey, string planKey);

        IDeletePlanCommand DeletePlan(string projectKey, string planKey);

        ICreatePlanCommand CreateBranch(string projectKey, string planKey, string branchName);

        IFavouritePlanCommand FavouritePlan(string projectKey, string planKey);

        IFavouritePlanCommand UnfavouritePlan(string projectKey, string planKey);
    }
}
