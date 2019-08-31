using System.Collections.Generic;
using PandaSharp.Attributes;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Common.Request;
using PandaSharp.Services.Plan.Aspect;
using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Plan.Response;
using RestSharp;

namespace PandaSharp.Services.Plan.Request
{
    [SupportsParameterAspect(nameof(ResultCountParameterAspect))]
    [SupportsParameterAspect(nameof(PlansExpandStateParameterAspect))]
    internal sealed class AllPlansRequest : RequestBase<PlansResponse>, IAllPlansRequest
    {
        protected override string ResourcePath => "plan";

        protected override string RootElement => "plans";

        protected override Method RequestMethod => Method.GET;

        public AllPlansRequest(IRestFactory restClientFactory, IList<IRequestParameterAspect> parameterAspects)
            : base(restClientFactory, parameterAspects)
        {
            ApplyToAspect<IExpandStateParameterAspectBase<PlansExpandState>>(aspect => aspect.ExpandState = PlansExpandState.OnlyBasicInformation);
        }

        public IAllPlansRequest IncludeDetails()
        {
            ApplyToAspect<IExpandStateParameterAspectBase<PlansExpandState>>(aspect => aspect.ExpandState |= PlansExpandState.IncludingDetails);
            return this;
        }

        public IAllPlansRequest IncludeActionsInformation()
        {
            ApplyToAspect<IExpandStateParameterAspectBase<PlansExpandState>>(aspect => aspect.ExpandState |= PlansExpandState.IncludingActions);
            return this;
        }

        public IAllPlansRequest IncludeStagesInformation()
        {
            ApplyToAspect<IExpandStateParameterAspectBase<PlansExpandState>>(aspect => aspect.ExpandState |= PlansExpandState.IncludingStages);
            return this;
        }

        public IAllPlansRequest IncludeBranchesInformation()
        {
            ApplyToAspect<IExpandStateParameterAspectBase<PlansExpandState>>(aspect => aspect.ExpandState |= PlansExpandState.IncludingBranches);
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
    }
}
