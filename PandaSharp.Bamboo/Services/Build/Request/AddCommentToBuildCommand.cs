using Newtonsoft.Json.Linq;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
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
            return Method.Post;
        }

        protected override void ApplyToRestRequest(RestRequest restRequest)
        {
            var json = new JObject
            {
                { "content", Comment }
            };

            restRequest.AddJsonBody(json);
        }
    }
}
