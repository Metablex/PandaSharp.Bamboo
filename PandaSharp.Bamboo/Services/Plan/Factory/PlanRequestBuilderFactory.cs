using System;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.IoC.Injections;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Factory
{
    internal sealed class PlanRequestBuilderFactory : IPlanRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public PlanRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IGetAllPlansRequest GetAllPlans()
        {
            return _container.Resolve<IGetAllPlansRequest>();
        }

        public IGetInformationOfPlanRequest GetInformationOfPlan(string projectKey, string planKey)
        {
            return _container.Resolve<IGetInformationOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey));
        }

        public IGetBranchesOfPlanRequest GetBranchesOfPlan(string projectKey, string planKey)
        {
            return _container.Resolve<IGetBranchesOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey));
        }

        public IGetArtifactsOfPlanRequest GetArtifactsOfPlan(string projectKey, string planKey)
        {
            return _container.Resolve<IGetArtifactsOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey));
        }

        public IGetLabelsOfPlanRequest GetLabelsOfPlan(string projectKey, string planKey)
        {
            return _container.Resolve<IGetLabelsOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey));
        }

        public IGetVcsBranchesOfPlanRequest GetVcsBranchesOfPlan(string projectKey, string planKey)
        {
            return _container.Resolve<IGetVcsBranchesOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey));
        }

        public IAddLabelToPlanCommand AddLabelToPlan(string projectKey, string planKey, string labelName)
        {
            return _container.Resolve<IAddLabelToPlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.Label, labelName));
        }

        public IDeleteLabelOfPlanCommand DeleteLabelOfPlan(string projectKey, string planKey, string labelName)
        {
            return _container.Resolve<IDeleteLabelOfPlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.Label, labelName));
        }

        public IEnableDisablePlanCommand EnablePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IEnableDisablePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.SetEnabled, true));
        }

        public IEnableDisablePlanCommand DisablePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IEnableDisablePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.SetEnabled, false));
        }

        public IDeletePlanCommand DeletePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IDeletePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey));
        }

        public ICreatePlanCommand CreateBranch(string projectKey, string planKey, string branchName)
        {
            if (branchName.Contains("/"))
            {
                throw new ArgumentException($"parameter {nameof(branchName)} must not contain any slashes");
            }

            return _container.Resolve<ICreatePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.Branch, branchName));
        }

        public IFavouritePlanCommand FavouritePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IFavouritePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.SetFavourite, true));
        }

        public IFavouritePlanCommand UnfavouritePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IFavouritePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKey, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKey, planKey),
                new InjectProperty(RequestPropertyNames.SetFavourite, false));
        }
    }
}
