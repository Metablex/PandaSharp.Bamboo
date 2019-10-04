using PandaSharp.Attributes;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Common.Request;
using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Plan.Response;
using RestSharp;

namespace PandaSharp.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<PlansExpandState>))]
    internal sealed class AllPlansRequest : RequestBase<PlansResponse>, IAllPlansRequest
    {
        public AllPlansRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IAllPlansRequest IncludeDetails()
        {
            ApplyToAspect<IExpandStateParameterAspect<PlansExpandState>>(aspect => aspect.AddExpandState(PlansExpandState.IncludingDetails));
            return this;
        }

        public IAllPlansRequest IncludeActionsInformation()
        {
            ApplyToAspect<IExpandStateParameterAspect<PlansExpandState>>(aspect => aspect.AddExpandState(PlansExpandState.IncludingActions));
            return this;
        }

        public IAllPlansRequest IncludeStagesInformation()
        {
            ApplyToAspect<IExpandStateParameterAspect<PlansExpandState>>(aspect => aspect.AddExpandState(PlansExpandState.IncludingStages));
            return this;
        }

        public IAllPlansRequest IncludeBranchesInformation()
        {
            ApplyToAspect<IExpandStateParameterAspect<PlansExpandState>>(aspect => aspect.AddExpandState(PlansExpandState.IncludingBranches));
            return this;
        }

        public IAllPlansRequest WithMaxResult(int maxResult)
        {
            ApplyToAspect<IResultCountParameterAspect>(aspect => aspect.MaxResults = maxResult);
            return this;
        }

        public IAllPlansRequest StartAtIndex(int startIndex)
        {
            ApplyToAspect<IResultCountParameterAspect>(aspect => aspect.StartIndex = startIndex);
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

        protected override string GetRootElement()
        {
            return "plans";
        }
    }
}
