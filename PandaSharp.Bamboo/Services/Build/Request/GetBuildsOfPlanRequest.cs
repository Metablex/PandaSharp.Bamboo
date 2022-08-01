using System;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IBuildStateParameterAspect))]
    [SupportsParameterAspect(typeof(IIssueFilterParameterAspect))]
    [SupportsParameterAspect(typeof(ILabelFilterParameterAspect))]
    [SupportsParameterAspect(typeof(IGetBuildsOfPlanParameterAspect))]
    internal sealed class GetBuildsOfPlanRequest : BuildRequestBase<BuildListResponse>, IGetBuildsOfPlanRequest
    {
        public GetBuildsOfPlanRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverter restResponseConverter)
            : base(restClientFactory, parameterAspectFactory, restResponseConverter)
        {
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
            if (ProjectKey.IsNullOrEmpty() || PlanKey.IsNullOrEmpty())
            {
                return "result";
            }

            return $"result/{ProjectKey}-{PlanKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}