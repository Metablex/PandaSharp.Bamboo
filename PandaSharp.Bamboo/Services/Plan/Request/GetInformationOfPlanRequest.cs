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
    [SupportsParameterAspect(typeof(IGetInformationOfPlanParameterAspect))]
    internal sealed class GetInformationOfPlanRequest : PlanRequestBase<PlanResponse>, IGetInformationOfPlanRequest
    {
        public GetInformationOfPlanRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
        }

        public IGetInformationOfPlanRequest WithMaxBranchResults(int maxResults = 25)
        {
            GetAspect<IResultCountParameterAspect>().SetMaxResults(maxResults);
            return this;
        }

        public IGetInformationOfPlanRequest IncludePlanInformation(params Action<IPlanInformationExpansion>[] expansions)
        {
            GetAspect<IGetInformationOfPlanParameterAspect>().IncludePlanInformation(expansions);
            return this;
        }

        protected override string GetResourcePath()
        {
            return $"plan/{ProjectKey}-{PlanKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
