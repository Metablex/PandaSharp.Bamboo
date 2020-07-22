using Newtonsoft.Json.Linq;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
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
            return Method.POST;
        }

        protected override void ApplyToRestRequest(IRestRequest restRequest)
        {
            var json = new JObject
            {
                { "name", LabelName }
            };

            restRequest.AddJsonBody(json);
        }
    }
}