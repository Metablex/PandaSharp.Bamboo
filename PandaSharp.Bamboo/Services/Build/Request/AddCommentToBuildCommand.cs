using Newtonsoft.Json.Linq;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    internal sealed class AddCommentToBuildCommand : BuildCommandBase, IAddCommentToBuildCommand
    {
        [InjectedProperty(RequestPropertyNames.Comment)]
        public string Comment { get; set; }

        public AddCommentToBuildCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"result/{ProjectKey}-{PlanKey}-{BuildNumber}/comment";
        }

        protected override Method GetRequestMethod()
        {
            return Method.POST;
        }

        protected override void ApplyToRestRequest(IRestRequest restRequest)
        {
            var json = new JObject(
                new JProperty("content", Comment));

            restRequest.AddJsonBody(json);
        }
    }
}