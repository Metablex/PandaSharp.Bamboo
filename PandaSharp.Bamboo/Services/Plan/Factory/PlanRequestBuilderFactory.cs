using System;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Common;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;

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
            var restFactory = CreateRestFactory();

            return new GetAllPlansRequest(
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetInformationOfPlanRequest GetInformationOfPlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);

            return new GetInformationOfPlanRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetBranchesOfPlanRequest GetBranchesOfPlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);

            return new GetBranchesOfPlanRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetArtifactsOfPlanRequest GetArtifactsOfPlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);

            return new GetArtifactsOfPlanRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetLabelsOfPlanRequest GetLabelsOfPlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);

            return new GetLabelsOfPlanRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IGetVcsBranchesOfPlanRequest GetVcsBranchesOfPlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);

            return new GetVcsBranchesOfPlanRequest(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        public IAddLabelToPlanCommand AddLabelToPlan(string projectKey, string planKey, string labelName)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.Label, labelName);

            return new AddLabelToPlanCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public IDeleteLabelOfPlanCommand DeleteLabelOfPlan(string projectKey, string planKey, string labelName)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.Label, labelName);

            return new DeleteLabelOfPlanCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public IEnableDisablePlanCommand EnablePlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.SetEnabled, true);

            return new EnableDisablePlanCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public IEnableDisablePlanCommand DisablePlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.SetEnabled, false);

            return new EnableDisablePlanCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public IDeletePlanCommand DeletePlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);

            return new DeletePlanCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public ICreatePlanCommand CreateBranch(string projectKey, string planKey, string branchName)
        {
            if (branchName.Contains("/"))
            {
                throw new ArgumentException($"parameter {nameof(branchName)} must not contain any slashes");
            }

            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.Branch, branchName);

            return new CreatePlanCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public IFavouritePlanCommand FavouritePlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.SetFavourite, true);

            return new FavouritePlanCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        public IFavouritePlanCommand UnfavouritePlan(string projectKey, string planKey)
        {
            var restFactory = CreateRestFactory();

            var context = new RestCommunicationContext();
            context.AddContextParameter(RequestPropertyNames.ProjectKey, projectKey);
            context.AddContextParameter(RequestPropertyNames.PlanKey, planKey);
            context.AddContextParameter(RequestPropertyNames.SetFavourite, false);

            return new FavouritePlanCommand(
                context,
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>());
        }

        private IRestFactory CreateRestFactory()
        {
            return new RestFactory(_container.Resolve<IRestOptions>(), JsonRestSerializer.Default);
        }
    }
}
