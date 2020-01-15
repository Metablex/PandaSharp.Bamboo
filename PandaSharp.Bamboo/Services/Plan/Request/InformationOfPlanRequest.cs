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
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<PlanExpandState>))]
    internal sealed class InformationOfPlanRequest : PlanRequestBase<PlanResponse>, IInformationOfPlanRequest
    {
        public InformationOfPlanRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IInformationOfPlanRequest IncludeActions()
        {
            GetAspect<IExpandStateParameterAspect<PlanExpandState>>().AddExpandState(PlanExpandState.IncludingActions);
            return this;
        }

        public IInformationOfPlanRequest IncludeStages()
        {
            GetAspect<IExpandStateParameterAspect<PlanExpandState>>().AddExpandState(PlanExpandState.IncludingStages);
            return this;
        }

        public IInformationOfPlanRequest IncludeBranches(int maxResults = 25)
        {
            GetAspect<IExpandStateParameterAspect<PlanExpandState>>().AddExpandState(PlanExpandState.IncludingBranches);
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResults;
            return this;
        }

        public IInformationOfPlanRequest IncludeVariableContext()
        {
            GetAspect<IExpandStateParameterAspect<PlanExpandState>>().AddExpandState(PlanExpandState.IncludingVariableContext);
            return this;
        }

        protected override string GetResourcePath()
        {
            return $"plan/{ProjectKey}-{PlanKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}