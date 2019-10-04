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
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<PlanExpandState>))]
    internal sealed class InformationOfRequest : RequestBase<PlanResponse>, IInformationOfRequest
    {
        [Dependency(RequestPropertyNames.PlanKeyName)]
        public string PlanKey { get; set; }

        public InformationOfRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IInformationOfRequest IncludeActions()
        {
            ApplyToAspect<IExpandStateParameterAspect<PlanExpandState>>(aspect => aspect.AddExpandState(PlanExpandState.IncludingActions));
            return this;
        }

        public IInformationOfRequest IncludeStages()
        {
            ApplyToAspect<IExpandStateParameterAspect<PlanExpandState>>(aspect => aspect.AddExpandState(PlanExpandState.IncludingStages));
            return this;
        }

        public IInformationOfRequest IncludeBranches(int maxResults = 25)
        {
            ApplyToAspect<IExpandStateParameterAspect<PlanExpandState>>(aspect => aspect.AddExpandState(PlanExpandState.IncludingBranches));
            ApplyToAspect<IResultCountParameterAspect>(aspect => aspect.MaxResults = maxResults);
            return this;
        }

        public IInformationOfRequest IncludeVariableContext()
        {
            ApplyToAspect<IExpandStateParameterAspect<PlanExpandState>>(aspect => aspect.AddExpandState(PlanExpandState.IncludingVariableContext));
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