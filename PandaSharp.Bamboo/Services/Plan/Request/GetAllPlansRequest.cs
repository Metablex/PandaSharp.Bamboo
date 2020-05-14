using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Bamboo.Services.Plan.Types;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<PlansExpandState>))]
    internal sealed class GetAllPlansRequest : PlanRequestBase<PlanListResponse>, IGetAllPlansRequest
    {
        public GetAllPlansRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IGetAllPlansRequest IncludeDetails()
        {
            GetAspect<IExpandStateParameterAspect<PlansExpandState>>().AddExpandState(PlansExpandState.IncludingDetails);
            return this;
        }

        public IGetAllPlansRequest IncludeActions()
        {
            GetAspect<IExpandStateParameterAspect<PlansExpandState>>().AddExpandState(PlansExpandState.IncludingActions);
            return this;
        }

        public IGetAllPlansRequest IncludeStages()
        {
            GetAspect<IExpandStateParameterAspect<PlansExpandState>>().AddExpandState(PlansExpandState.IncludingStages);
            return this;
        }

        public IGetAllPlansRequest IncludeBranches()
        {
            GetAspect<IExpandStateParameterAspect<PlansExpandState>>().AddExpandState(PlansExpandState.IncludingBranches);
            return this;
        }

        public IGetAllPlansRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResult;
            return this;
        }

        public IGetAllPlansRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().StartIndex = startIndex;
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
