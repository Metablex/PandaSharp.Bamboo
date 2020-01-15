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

        public IAllPlansRequest AllPlans()
        {
            return _container.Resolve<IAllPlansRequest>();
        }

        public IInformationOfPlanRequest InformationOf(string projectKey, string planKey)
        {
            return _container.Resolve<IInformationOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }

        public IBranchesOfPlanRequest BranchesOf(string projectKey, string planKey)
        {
            return _container.Resolve<IBranchesOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }

        public IArtifactsOfPlanRequest ArtifactsOf(string projectKey, string planKey)
        {
            return _container.Resolve<IArtifactsOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }

        public ILabelsOfPlanRequest LabelsOf(string projectKey, string planKey)
        {
            return _container.Resolve<ILabelsOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }

        public IVcsBranchesOfPlanRequest VcsBranchesOf(string projectKey, string planKey)
        {
            return _container.Resolve<IVcsBranchesOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }

        public ILabelsOfPlanRequest AddLabelToPlan(string projectKey, string planKey, string labelName)
        {
            return _container.Resolve<ILabelsOfPlanRequest>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.LabelName, labelName));
        }

        public IDeleteLabelOfPlanCommand DeleteLabelOfPlan(string projectKey, string planKey, string labelName)
        {
            return _container.Resolve<IDeleteLabelOfPlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.LabelName, labelName));
        }

        public IEnableDisablePlanCommand EnablePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IEnableDisablePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.SetEnabledName, true));
        }

        public IEnableDisablePlanCommand DisablePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IEnableDisablePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.SetEnabledName, false));
        }

        public IDeletePlanCommand DeletePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IDeletePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey));
        }

        public ICreatePlanCommand CreateBranch(string projectKey, string planKey, string branchName)
        {
            if (branchName.Contains("/"))
            {
                throw new ArgumentException($"parameter {nameof(branchName)} must not contain any backslashes");
            }

            return _container.Resolve<ICreatePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.BranchName, branchName));
        }

        public IFavouritePlanCommand FavouritePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IFavouritePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.SetFavouriteName, true));
        }

        public IFavouritePlanCommand UnfavouritePlan(string projectKey, string planKey)
        {
            return _container.Resolve<IFavouritePlanCommand>(
                new InjectProperty(RequestPropertyNames.ProjectKeyName, projectKey),
                new InjectProperty(RequestPropertyNames.PlanKeyName, planKey),
                new InjectProperty(RequestPropertyNames.SetFavouriteName, false));
        }
    }
}
