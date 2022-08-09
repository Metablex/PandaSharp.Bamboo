using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    internal sealed class GetLabelsOfBuildRequest : BuildRequestBase<LabelListResponse>, IGetLabelsOfBuildRequest
    {
        public GetLabelsOfBuildRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverter restResponseConverter)
            : base(restClientFactory, parameterAspectFactory, restResponseConverter)
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