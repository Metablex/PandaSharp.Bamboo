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
    [SupportsParameterAspect(typeof(IPlansExpandStateParameterAspect))]
    internal sealed class AllPlansRequest : RequestBase<PlansResponse>, IAllPlansRequest
    {
        public AllPlansRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
            ApplyToAspect<IPlansExpandStateParameterAspect>(aspect => aspect.ExpandState = PlansExpandState.OnlyBasicInformation);
        }

        public IAllPlansRequest IncludeDetails()
        {
            ApplyToAspect<IPlansExpandStateParameterAspect>(aspect => aspect.ExpandState |= PlansExpandState.IncludingDetails);
            return this;
        }

        public IAllPlansRequest IncludeActionsInformation()
        {
            ApplyToAspect<IPlansExpandStateParameterAspect>(aspect => aspect.ExpandState |= PlansExpandState.IncludingActions);
            return this;
        }

        public IAllPlansRequest IncludeStagesInformation()
        {
            ApplyToAspect<IPlansExpandStateParameterAspect>(aspect => aspect.ExpandState |= PlansExpandState.IncludingStages);
            return this;
        }

        public IAllPlansRequest IncludeBranchesInformation()
        {
            ApplyToAspect<IPlansExpandStateParameterAspect>(aspect => aspect.ExpandState |= PlansExpandState.IncludingBranches);
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
