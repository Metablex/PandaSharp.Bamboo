using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class DeleteLabelOfPlanCommand : CommandBase, IDeleteLabelOfPlanCommand
    {
        private readonly IRestCommunicationContext _communicationContext;

        public DeleteLabelOfPlanCommand(
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
            var labelName = _communicationContext.GetContextParameter<string>(RequestPropertyNames.Label);

            return $"plan/{projectKey}-{planKey}/label/{labelName}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Delete;
        }
    }
}
