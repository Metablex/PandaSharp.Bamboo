using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IGetBranchesOfPlanParameterAspect))]
    internal sealed class GetBranchesOfPlanRequest : RequestBase<BranchListResponse>, IGetBranchesOfPlanRequest
    {
        private readonly IRestCommunicationContext _communicationContext;

        public GetBranchesOfPlanRequest(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory,
            IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
            _communicationContext = communicationContext;
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
            var projectKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.ProjectKey);
            var planKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.PlanKey);

            return $"plan/{projectKey}-{planKey}/branch";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
