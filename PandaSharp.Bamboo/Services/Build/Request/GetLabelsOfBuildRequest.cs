using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    internal sealed class GetLabelsOfBuildRequest : BuildRequestBase<LabelListResponse>, IGetLabelsOfBuildRequest
    {
        public GetLabelsOfBuildRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"result/{ProjectKey}-{PlanKey}-{BuildNumber}/label";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}