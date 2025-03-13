using System;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Expansion;
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
    [SupportsParameterAspect(typeof(IGetInformationOfPlanParameterAspect))]
    internal sealed class GetInformationOfPlanRequest : RequestBase<PlanResponse>, IGetInformationOfPlanRequest
    {
        private readonly IRestCommunicationContext _communicationContext;

        public GetInformationOfPlanRequest(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory,
            IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
            _communicationContext = communicationContext;
        }

        public IGetInformationOfPlanRequest WithMaxBranchResults(int maxResults = 25)
        {
            GetAspect<IResultCountParameterAspect>().SetMaxResults(maxResults);
            return this;
        }

        public IGetInformationOfPlanRequest IncludePlanInformation(params Action<IPlanInformationExpansion>[] expansions)
        {
            GetAspect<IGetInformationOfPlanParameterAspect>().IncludePlanInformation(expansions);
            return this;
        }

        protected override string GetResourcePath()
        {
            var projectKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.ProjectKey);
            var planKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.PlanKey);

            return $"plan/{projectKey}-{planKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
