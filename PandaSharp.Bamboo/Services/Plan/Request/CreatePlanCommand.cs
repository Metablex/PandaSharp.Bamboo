using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(ICreatePlanParameterAspect))]
    internal sealed class CreatePlanCommand : CommandBase, ICreatePlanCommand
    {
        private readonly IRestCommunicationContext _communicationContext;

        public CreatePlanCommand(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
            _communicationContext = communicationContext;
        }

        public ICreatePlanCommand WithVcsBranch(string vcsBranch)
        {
            GetAspect<ICreatePlanParameterAspect>().SetVcsBranchFilter(vcsBranch);
            return this;
        }

        public ICreatePlanCommand WithEnabledState(bool isEnabled)
        {
            GetAspect<ICreatePlanParameterAspect>().SetIsEnabledFilter(isEnabled);
            return this;
        }

        public ICreatePlanCommand WithCleanupEnabled(bool isCleanupEnabled)
        {
            GetAspect<ICreatePlanParameterAspect>().SetIsCleanupEnabledFilter(isCleanupEnabled);
            return this;
        }

        protected override string GetResourcePath()
        {
            var projectKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.ProjectKey);
            var planKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.PlanKey);
            var branchName = _communicationContext.GetContextParameter<string>(RequestPropertyNames.Branch);

            return $"plan/{projectKey}-{planKey}/branch/{branchName}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Put;
        }
    }
}
