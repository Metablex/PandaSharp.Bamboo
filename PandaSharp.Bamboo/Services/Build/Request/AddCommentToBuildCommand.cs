using Newtonsoft.Json.Linq;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    internal sealed class AddCommentToBuildCommand : CommandBase, IAddCommentToBuildCommand
    {
        private readonly IRestCommunicationContext _communicationContext;

        public AddCommentToBuildCommand(
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
            var buildNumber = _communicationContext.GetContextParameter<string>(RequestPropertyNames.BuildNumber);

            return $"result/{projectKey}-{planKey}-{buildNumber}/comment";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Post;
        }

        protected override void ApplyToRestRequest(RestRequest restRequest)
        {
            var comment = _communicationContext.GetContextParameter<string>(RequestPropertyNames.Comment);

            var json = new JObject
            {
                { "content", comment }
            };

            restRequest.AddJsonBody(json);
        }
    }
}
