using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Common.Types;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IBuildStateParameterAspect))]
    [SupportsParameterAspect(typeof(IIssueFilterParameterAspect))]
    [SupportsParameterAspect(typeof(ILabelFilterParameterAspect))]
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<BuildListExpandState>))]
    internal sealed class BuildListRequest : RequestBase<BuildListResponse>, IBuildListRequest
    {
        [InjectedProperty(RequestPropertyNames.ProjectKeyName)]
        public string ProjectKey { get; set; }

        [InjectedProperty(RequestPropertyNames.PlanKeyName)]
        public string PlanKey { get; set; }

        public BuildListRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IBuildListRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResult;
            return this;
        }

        public IBuildListRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().StartIndex = startIndex;
            return this;
        }

        public IBuildListRequest OnlyFailedBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().BuildState = BuildState.Failed;
            return this;
        }

        public IBuildListRequest OnlySuccessfulBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().BuildState = BuildState.Successful;
            return this;
        }

        public IBuildListRequest OnlyUncompletedBuilds()
        {
            GetAspect<IBuildStateParameterAspect>().BuildState = BuildState.Unknown;
            return this;
        }

        public IBuildListRequest OnlyWithIssues(params string[] jiraIssues)
        {
            GetAspect<IIssueFilterParameterAspect>().Issues = jiraIssues;
            return this;
        }

        public IBuildListRequest OnlyWithLabels(params string[] labels)
        {
            GetAspect<ILabelFilterParameterAspect>().Labels = labels;
            return this;
        }

        public IBuildListRequest IncludingDetails()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingDetails);
            return this;
        }

        public IBuildListRequest IncludingArtifacts()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingArtifacts);
            return this;
        }

        public IBuildListRequest IncludingComments()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingComments);
            return this;
        }

        public IBuildListRequest IncludingLabels()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingLabels);
            return this;
        }

        public IBuildListRequest IncludingJiraIssues()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingJiraIssues);
            return this;
        }

        public IBuildListRequest IncludingVariables()
        {
            GetAspect<IExpandStateParameterAspect<BuildListExpandState>>().AddExpandState(BuildListExpandState.IncludingVariables);
            return this;
        }

        public IBuildListRequest IncludingStages()
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