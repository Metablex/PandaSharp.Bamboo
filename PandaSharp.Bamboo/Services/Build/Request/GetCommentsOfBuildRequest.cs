using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    internal sealed class GetCommentsOfBuildRequest : BuildRequestBase<CommentListResponse>, IGetCommentsOfBuildRequest
    {
        public GetCommentsOfBuildRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverter restResponseConverter)
            : base(restClientFactory, parameterAspectFactory, restResponseConverter)
        {
        }

        protected override string GetResourcePath()
        {
            return $"result/{ProjectKey}-{PlanKey}-{BuildNumber}/comment";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }

        protected override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest.AddParameter("expand", "comments.comment");
        }
    }
}