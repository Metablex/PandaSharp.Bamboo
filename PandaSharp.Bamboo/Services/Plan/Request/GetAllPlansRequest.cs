using System;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IGetAllPlansParameterAspect))]
    internal sealed class GetAllPlansRequest : PlanRequestBase<PlanListResponse>, IGetAllPlansRequest
    {
        public GetAllPlansRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverter restResponseConverter)
            : base(restClientFactory, parameterAspectFactory, restResponseConverter)
        {
        }

        public IGetAllPlansRequest IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions)
        {
            GetAspect<IGetAllPlansParameterAspect>().IncludePlanInformation(expansions);
            return this;
        }

        public IGetAllPlansRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().SetMaxResults(maxResult);
            return this;
        }

        public IGetAllPlansRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().SetStartIndex(startIndex);
            return this;
        }

        protected override string GetResourcePath()
        {
            return "plan";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}
