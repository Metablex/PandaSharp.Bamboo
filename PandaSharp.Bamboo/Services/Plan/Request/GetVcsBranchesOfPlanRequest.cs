using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
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
    internal sealed class GetVcsBranchesOfPlanRequest : RequestBase<VcsBranchListResponse>, IGetVcsBranchesOfPlanRequest
    {
        private readonly IRestCommunicationContext _communicationContext;

        public GetVcsBranchesOfPlanRequest(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory,
            IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
            _communicationContext = communicationContext;
        }

        public IGetVcsBranchesOfPlanRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().SetMaxResults(maxResult);
            return this;
        }

        public IGetVcsBranchesOfPlanRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().SetStartIndex(startIndex);
            return this;
        }

        protected override string GetResourcePath()
        {
            var projectKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.ProjectKey);
            var planKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.PlanKey);

            return $"plan/{projectKey}-{planKey}/vcsBranches";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
