using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    internal sealed class GetLabelsOfBuildRequest : RequestBase<LabelListResponse>, IGetLabelsOfBuildRequest
    {
        private readonly IRestCommunicationContext _communicationContext;

        public GetLabelsOfBuildRequest(
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
            var buildNumber = _communicationContext.GetContextParameter<string>(RequestPropertyNames.BuildNumber);

            return $"result/{projectKey}-{planKey}-{buildNumber}/label";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
