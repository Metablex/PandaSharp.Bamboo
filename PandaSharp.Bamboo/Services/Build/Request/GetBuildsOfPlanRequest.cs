using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IBuildStateParameterAspect))]
    [SupportsParameterAspect(typeof(IIssueFilterParameterAspect))]
    [SupportsParameterAspect(typeof(ILabelFilterParameterAspect))]
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<BuildListExpandState>))]
    internal sealed class GetBuildsOfPlanRequest : BuildRequestBase<BuildListResponse>, IGetBuildsOfPlanRequest
    {
        public GetBuildsOfPlanRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IGetBuildsOfPlanRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResult;
            return this;
        }

        public IGetBuildsOfPlanRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().StartIndex = startIndex;
            return this;
        }

        public IGetBuildsOfPlanRequest OnlyFailedBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().BuildState = BuildState.Failed;
            return this;
        }

        public IGetBuildsOfPlanRequest OnlySuccessfulBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().BuildState = BuildState.Successful;
            return this;
        }

        public IGetBuildsOfPlanRequest OnlyUncompletedBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().BuildState = BuildState.Unknown;
            return this;
        }

        public IGetBuildsOfPlanRequest OnlyWithIssues(params string[] jiraIssues)
        {
            GetAspect<IIssueFilterParameterAspect>().Issues = jiraIssues;
            return this;
        }

        public IGetBuildsOfPlanRequest OnlyWithLabels(params string[] labels)
        {
            GetAspect<ILabelFilterParameterAspect>().Labels = labels;
            return this;
        }

        public IGetBuildsOfPlanRequest IncludingDetails()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingDetails);
            return this;
        }

        public IGetBuildsOfPlanRequest IncludingArtifacts()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingArtifacts);
            return this;
        }

        public IGetBuildsOfPlanRequest IncludingComments()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingComments);
            return this;
        }

        public IGetBuildsOfPlanRequest IncludingLabels()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingLabels);
            return this;
        }

        public IGetBuildsOfPlanRequest IncludingJiraIssues()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingJiraIssues);
            return this;
        }

        public IGetBuildsOfPlanRequest IncludingVariables()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingVariables);
            return this;
        }

        public IGetBuildsOfPlanRequest IncludingStages()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingStages);
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