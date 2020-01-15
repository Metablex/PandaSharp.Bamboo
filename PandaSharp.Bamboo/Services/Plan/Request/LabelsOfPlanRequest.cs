using Newtonsoft.Json.Linq;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class LabelsOfPlanRequest : PlanRequestBase<LabelListResponse>, ILabelsOfPlanRequest
    {
        [InjectedProperty(RequestPropertyNames.LabelName)]
        public string LabelName { get; set; }

        public LabelsOfPlanRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"plan/{ProjectKey}-{PlanKey}/label";
        }

        protected override Method GetRequestMethod()
        {
            return string.IsNullOrEmpty(LabelName)
                ? Method.GET
                : Method.POST;
        }

        protected override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (!string.IsNullOrEmpty(LabelName))
            {
                var json = new JObject(new JProperty("name", LabelName));

                restRequest.AddJsonBody(json);
            }
        }
    }
}