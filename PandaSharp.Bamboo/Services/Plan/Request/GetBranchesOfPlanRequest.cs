using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IGetBranchesOfPlanParameterAspect))]
    internal sealed class GetBranchesOfPlanRequest : PlanRequestBase<BranchListResponse>, IGetBranchesOfPlanRequest
    {
        public GetBranchesOfPlanRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
        }

        public IGetBranchesOfPlanRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().SetMaxResults(maxResult);
            return this;
        }

        public IGetBranchesOfPlanRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().SetStartIndex(startIndex);
            return this;
        }

        public IGetBranchesOfPlanRequest OnlyEnabledBranches()
        {
            GetAspect<IGetBranchesOfPlanParameterAspect>().SetOnlyEnabledBranchesFilter(true);
            return this;
        }

        protected override string GetResourcePath()
        {
            return $"plan/{ProjectKey}-{PlanKey}/branch";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
