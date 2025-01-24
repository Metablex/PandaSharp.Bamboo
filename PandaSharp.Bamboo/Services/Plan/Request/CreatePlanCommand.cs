using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(ICreatePlanParameterAspect))]
    internal sealed class CreatePlanCommand : PlanCommandBase, ICreatePlanCommand
    {
        [InjectedProperty(RequestPropertyNames.Branch)]
        public string BranchName { get; set; }

        public CreatePlanCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
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
            return $"plan/{ProjectKey}-{PlanKey}/branch/{BranchName}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Put;
        }
    }
}
