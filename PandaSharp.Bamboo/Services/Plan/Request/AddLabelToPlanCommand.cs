using Newtonsoft.Json.Linq;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class AddLabelToPlanCommand : PlanCommandBase, IAddLabelToPlanCommand
    {
        [InjectedProperty(RequestPropertyNames.Label)]
        public string LabelName { get; set; }

        public AddLabelToPlanCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"plan/{ProjectKey}-{PlanKey}/label";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Post;
        }

        protected override void ApplyToRestRequest(RestRequest restRequest)
        {
            var json = new JObject
            {
                { "name", LabelName }
            };

            restRequest.AddJsonBody(json);
        }
    }
}
