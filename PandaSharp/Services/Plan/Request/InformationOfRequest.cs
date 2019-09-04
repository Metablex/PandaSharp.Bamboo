using PandaSharp.Attributes;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Common.Request;
using PandaSharp.Services.Plan.Contract;
using PandaSharp.Services.Plan.Response;
using RestSharp;
using Unity;

namespace PandaSharp.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IPlanExpandStateParameterAspect))]
    internal sealed class InformationOfRequest : RequestBase<PlanResponse>, IInformationOfRequest
    {
        [Dependency]
        public string PlanKey { get; set; }

        public InformationOfRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IInformationOfRequest IncludeActions()
        {
            ApplyToAspect<IPlanExpandStateParameterAspect>(aspect => aspect.ExpandState |= PlanExpandState.IncludingActions);
            return this;
        }

        public IInformationOfRequest IncludeStages()
        {
            ApplyToAspect<IPlanExpandStateParameterAspect>(aspect => aspect.ExpandState |= PlanExpandState.IncludingStages);
            return this;
        }

        public IInformationOfRequest IncludeBranches(int maxResults = 25)
        {
            ApplyToAspect<IPlanExpandStateParameterAspect>(aspect => aspect.ExpandState |= PlanExpandState.IncludingBranches);
            ApplyToAspect<IResultCountParameterAspect>(aspect => aspect.MaxResults = maxResults);
            return this;
        }

        public IInformationOfRequest IncludeVariableContext()
        {
            ApplyToAspect<IPlanExpandStateParameterAspect>(aspect => aspect.ExpandState |= PlanExpandState.IncludingVariableContext);
            return this;
        }

        protected override string GetResourcePath()
        {
            return $"plan/{PlanKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}