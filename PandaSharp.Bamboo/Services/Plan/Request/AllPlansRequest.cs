using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<PlansExpandState>))]
    internal sealed class AllPlansRequest : RequestBase<PlanListResponse>, IAllPlansRequest
    {
        public AllPlansRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IAllPlansRequest IncludeDetails()
        {
            GetAspect<IExpandStateParameterAspect<PlansExpandState>>().AddExpandState(PlansExpandState.IncludingDetails);
            return this;
        }

        public IAllPlansRequest IncludeActions()
        {
            GetAspect<IExpandStateParameterAspect<PlansExpandState>>().AddExpandState(PlansExpandState.IncludingActions);
            return this;
        }

        public IAllPlansRequest IncludeStages()
        {
            GetAspect<IExpandStateParameterAspect<PlansExpandState>>().AddExpandState(PlansExpandState.IncludingStages);
            return this;
        }

        public IAllPlansRequest IncludeBranches()
        {
            GetAspect<IExpandStateParameterAspect<PlansExpandState>>().AddExpandState(PlansExpandState.IncludingBranches);
            return this;
        }

        public IAllPlansRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResult;
            return this;
        }

        public IAllPlansRequest StartAtIndex(int startIndex)
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
