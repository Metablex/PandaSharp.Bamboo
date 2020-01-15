using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IBuildStateParameterAspect))]
    [SupportsParameterAspect(typeof(IIssueFilterParameterAspect))]
    [SupportsParameterAspect(typeof(ILabelFilterParameterAspect))]
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<BuildListExpandState>))]
    internal sealed class MultipleBuildsRequest : BuildRequestBase<BuildListResponse>, IMultipleBuildsRequest
    {
        public MultipleBuildsRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IMultipleBuildsRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResult;
            return this;
        }

        public IMultipleBuildsRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().StartIndex = startIndex;
            return this;
        }

        public IMultipleBuildsRequest OnlyFailedBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().BuildState = BuildState.Failed;
            return this;
        }

        public IMultipleBuildsRequest OnlySuccessfulBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().BuildState = BuildState.Successful;
            return this;
        }

        public IMultipleBuildsRequest OnlyUncompletedBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().BuildState = BuildState.Unknown;
            return this;
        }

        public IMultipleBuildsRequest OnlyWithIssues(params string[] jiraIssues)
        {
            GetAspect<IIssueFilterParameterAspect>().Issues = jiraIssues;
            return this;
        }

        public IMultipleBuildsRequest OnlyWithLabels(params string[] labels)
        {
            GetAspect<ILabelFilterParameterAspect>().Labels = labels;
            return this;
        }

        public IMultipleBuildsRequest IncludingDetails()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingDetails);
            return this;
        }

        public IMultipleBuildsRequest IncludingArtifacts()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingArtifacts);
            return this;
        }

        public IMultipleBuildsRequest IncludingComments()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingComments);
            return this;
        }

        public IMultipleBuildsRequest IncludingLabels()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingLabels);
            return this;
        }

        public IMultipleBuildsRequest IncludingJiraIssues()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingJiraIssues);
            return this;
        }

        public IMultipleBuildsRequest IncludingVariables()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingVariables);
            return this;
        }

        public IMultipleBuildsRequest IncludingStages()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingStages);
            return this;
        }

        protected override string GetResourcePath()
        {
            if (string.IsNullOrEmpty(ProjectKey) || string.IsNullOrEmpty(PlanKey))
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