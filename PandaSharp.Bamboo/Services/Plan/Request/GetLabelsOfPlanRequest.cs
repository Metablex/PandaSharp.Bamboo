using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class GetLabelsOfPlanRequest : RequestBase<LabelListResponse>, IGetLabelsOfPlanRequest
    {
        private readonly IRestCommunicationContext _communicationContext;

        public GetLabelsOfPlanRequest(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory,
            IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
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
            return Method.Get;
        }
    }
}
