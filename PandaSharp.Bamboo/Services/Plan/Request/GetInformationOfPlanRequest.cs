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
    internal sealed class GetInformationOfPlanRequest : PlanRequestBase<PlanResponse>, IGetInformationOfPlanRequest
    {
        public GetInformationOfPlanRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IGetInformationOfPlanRequest IncludeActions()
        {
            GetAspect<IExpandStateParameterAspect<PlanExpandState>>().AddExpandState(PlanExpandState.IncludingActions);
            return this;
        }

        public IGetInformationOfPlanRequest IncludeStages()
        {
            GetAspect<IExpandStateParameterAspect<PlanExpandState>>().AddExpandState(PlanExpandState.IncludingStages);
            return this;
        }

        public IGetInformationOfPlanRequest IncludeBranches(int maxResults = 25)
        {
            GetAspect<IExpandStateParameterAspect<PlanExpandState>>().AddExpandState(PlanExpandState.IncludingBranches);
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResults;
            return this;
        }

        public IGetInformationOfPlanRequest IncludeVariableContext()
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