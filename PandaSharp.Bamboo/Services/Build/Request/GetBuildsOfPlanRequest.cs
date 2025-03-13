using System;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IBuildStateParameterAspect))]
    [SupportsParameterAspect(typeof(IIssueFilterParameterAspect))]
    [SupportsParameterAspect(typeof(ILabelFilterParameterAspect))]
    [SupportsParameterAspect(typeof(IGetBuildsOfPlanParameterAspect))]
    internal sealed class GetBuildsOfPlanRequest : RequestBase<BuildListResponse>, IGetBuildsOfPlanRequest
    {
        private readonly IRestCommunicationContext _communicationContext;

        public GetBuildsOfPlanRequest(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory,
            IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
            _communicationContext = communicationContext;
        }

        public IGetBuildsOfPlanRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().SetMaxResults(maxResult);
            return this;
        }

        public IGetBuildsOfPlanRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().SetStartIndex(startIndex);
            return this;
        }

        public IGetBuildsOfPlanRequest OnlyFailedBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().SetBuildStateFilter(BuildState.Failed);
            return this;
        }

        public IGetBuildsOfPlanRequest OnlySuccessfulBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().SetBuildStateFilter(BuildState.Successful);
            return this;
        }

        public IGetBuildsOfPlanRequest OnlyUncompletedBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().SetBuildStateFilter(BuildState.Unknown);
            return this;
        }

        public IGetBuildsOfPlanRequest OnlyWithIssues(params string[] jiraIssues)
        {
            GetAspect<IIssueFilterParameterAspect>().SetIssuesFilter(jiraIssues);
            return this;
        }

        public IGetBuildsOfPlanRequest OnlyWithLabels(params string[] labels)
        {
            GetAspect<ILabelFilterParameterAspect>().SetLabelsFilter(labels);
            return this;
        }

        public IGetBuildsOfPlanRequest IncludeBuildInformation(params Action<IBuildListInformationExpansion>[] expansions)
        {
            GetAspect<IGetBuildsOfPlanParameterAspect>().IncludeBuildInformation(expansions);
            return this;
        }

        protected override string GetResourcePath()
        {
            var projectKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.ProjectKey);
            var planKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.PlanKey);

            if (projectKey.IsNullOrEmpty() || planKey.IsNullOrEmpty())
            {
                return "result";
            }

            return $"result/{projectKey}-{planKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
