using System;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IGetInformationOfBuildParameterAspect))]
    internal sealed class GetInformationOfBuildRequest : RequestBase<BuildResponse>, IGetInformationOfBuildRequest
    {
        private readonly IRestCommunicationContext _communicationContext;

        public GetInformationOfBuildRequest(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory,
            IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
            _communicationContext = communicationContext;
        }

        public IGetInformationOfBuildRequest IncludeBuildInformation(params Action<IBuildInformationExpansion>[] expansions)
        {
            GetAspect<IGetInformationOfBuildParameterAspect>().IncludeBuildInformation(expansions);
            return this;
        }

        protected override string GetResourcePath()
        {
            var projectKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.ProjectKey);
            var planKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.PlanKey);
            var buildNumber = _communicationContext.GetContextParameter<string>(RequestPropertyNames.BuildNumber);

            return $"result/{projectKey}-{planKey}-{buildNumber}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
