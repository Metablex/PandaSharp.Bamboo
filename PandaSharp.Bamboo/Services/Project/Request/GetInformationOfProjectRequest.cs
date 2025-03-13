using System;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Response;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Request
{
    [SupportsParameterAspect(typeof(IGetInformationOfProjectRequestAspect))]
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    internal sealed class GetInformationOfProjectRequest : RequestBase<ProjectResponse>, IGetInformationOfProjectRequest
    {
        private readonly IRestCommunicationContext _communicationContext;

        public GetInformationOfProjectRequest(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory,
            IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
            _communicationContext = communicationContext;
        }

        public IGetInformationOfProjectRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().SetMaxResults(maxResult);
            return this;
        }

        public IGetInformationOfProjectRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().SetStartIndex(startIndex);
            return this;
        }

        public IGetInformationOfProjectRequest IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions)
        {
            GetAspect<IGetInformationOfProjectRequestAspect>().IncludePlanInformation(expansions);
            return this;
        }

        protected override string GetResourcePath()
        {
            var projectKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.ProjectKey);

            return $"project/{projectKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
