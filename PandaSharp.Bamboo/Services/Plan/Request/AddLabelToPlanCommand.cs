using Newtonsoft.Json.Linq;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class AddLabelToPlanCommand : CommandBase, IAddLabelToPlanCommand
    {
        private readonly IRestCommunicationContext _communicationContext;

        public AddLabelToPlanCommand(
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

            return $"plan/{projectKey}-{planKey}/label";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Post;
        }

        protected override void ApplyToRestRequest(RestRequest restRequest)
        {
            var labelName = _communicationContext.GetContextParameter<string>(RequestPropertyNames.Label);
            var json = new JObject
            {
                { "name", labelName }
            };

            restRequest.AddJsonBody(json);
        }
    }
}
