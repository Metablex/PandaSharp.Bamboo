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
    internal sealed class AddLabelToBuildCommand : BuildCommandBase, IAddLabelToBuildCommand
    {
        [InjectedProperty(RequestPropertyNames.Label)]
        public string Label { get; set; }

        public AddLabelToBuildCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"result/{ProjectKey}-{PlanKey}-{BuildNumber}/label";
        }

        protected override Method GetRequestMethod()
        {
            return Method.POST;
        }

        protected override void ApplyToRestRequest(IRestRequest restRequest)
        {
            var json = new JObject
            {
                { "name", Label }
            };

            restRequest.AddJsonBody(json);
        }
    }
}