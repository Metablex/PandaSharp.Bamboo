using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class EnableDisablePlanCommand : CommandBase, IEnableDisablePlanCommand
    {
        private readonly IRestCommunicationContext _communicationContext;

        public EnableDisablePlanCommand(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
            _communicationContext = communicationContext;
        }

        protected override string GetResourcePath()
        {
            var projectKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.ProjectKey);
            var planKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.PlanKey);

            return $"plan/{projectKey}-{planKey}/enable";
        }

        protected override Method GetRequestMethod()
        {
            var isEnablingRequested = _communicationContext.GetContextParameter<bool>(RequestPropertyNames.SetEnabled);

            return isEnablingRequested
                ? Method.Post
                : Method.Delete;
        }
    }
}
