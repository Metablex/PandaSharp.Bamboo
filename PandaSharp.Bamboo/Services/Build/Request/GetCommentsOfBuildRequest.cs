using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    internal sealed class GetCommentsOfBuildRequest : RequestBase<CommentListResponse>, IGetCommentsOfBuildRequest
    {
        private readonly IRestCommunicationContext _communicationContext;

        public GetCommentsOfBuildRequest(
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
            var buildNumber = _communicationContext.GetContextParameter<uint>(RequestPropertyNames.BuildNumber);

            return $"result/{projectKey}-{planKey}-{buildNumber}/comment";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }

        protected override void ApplyToRestRequest(RestRequest restRequest)
        {
            restRequest.AddParameter("expand", "comments.comment");
        }
    }
}
