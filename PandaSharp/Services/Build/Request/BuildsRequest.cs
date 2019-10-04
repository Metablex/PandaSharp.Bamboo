using PandaSharp.Attributes;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Build.Response;
using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Common.Request;
using RestSharp;
using Unity;

namespace PandaSharp.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IBuildStateParameterAspect))]
    [SupportsParameterAspect(typeof(IIssueFilterParameterAspect))]
    [SupportsParameterAspect(typeof(ILabelFilterParameterAspect))]
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<BuildsExpandState>))]
    internal sealed class BuildsRequest : RequestBase<BuildsResponse>, IBuildsRequest
    {
        [Dependency(RequestPropertyNames.ProjectKeyName)]
        public string ProjectKey { get; set; }

        [Dependency(RequestPropertyNames.PlanKeyName)]
        public string PlanKey { get; set; }

        public BuildsRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory) : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IBuildsRequest WithMaxResult(int maxResult)
        {
            ApplyToAspect<IResultCountParameterAspect>(aspect => aspect.MaxResults = maxResult);
            return this;
        }

        public IBuildsRequest StartAtIndex(int startIndex)
        {
            ApplyToAspect<IResultCountParameterAspect>(aspect => aspect.StartIndex = startIndex);
            return this;
        }

        public IBuildsRequest OnlyFailedBuilds()
        {
            ApplyToAspect<IBuildStateParameterAspect>(aspect => aspect.BuildState = BuildState.Failed);
            return this;
        }

        public IBuildsRequest OnlySuccessfulBuilds()
        {
            ApplyToAspect<IBuildStateParameterAspect>(aspect => aspect.BuildState = BuildState.Successful);
            return this;
        }

        public IBuildsRequest OnlyUncompletedBuilds()
        {
            ApplyToAspect<IBuildStateParameterAspect>(aspect => aspect.BuildState = BuildState.Unknown);
            return this;
        }

        public IBuildsRequest OnlyWithIssues(params string[] jiraIssues)
        {
            ApplyToAspect<IIssueFilterParameterAspect>(aspect => aspect.Issues = jiraIssues);
            return this;
        }

        public IBuildsRequest OnlyWithLabels(params string[] labels)
        {
            ApplyToAspect<ILabelFilterParameterAspect>(aspect => aspect.Labels = labels);
            return this;
        }

        public IBuildsRequest IncludingDetails()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildsExpandState>>(aspect => aspect.AddExpandState(BuildsExpandState.IncludingDetails));
            return this;
        }

        public IBuildsRequest IncludingArtifacts()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildsExpandState>>(aspect => aspect.AddExpandState(BuildsExpandState.IncludingArtifacts));
            return this;
        }

        public IBuildsRequest IncludingComments()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildsExpandState>>(aspect => aspect.AddExpandState(BuildsExpandState.IncludingComments));
            return this;
        }

        public IBuildsRequest IncludingLabels()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildsExpandState>>(aspect => aspect.AddExpandState(BuildsExpandState.IncludingLabels));
            return this;
        }

        public IBuildsRequest IncludingJiraIssues()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildsExpandState>>(aspect => aspect.AddExpandState(BuildsExpandState.IncludingJiraIssues));
            return this;
        }

        public IBuildsRequest IncludingVariables()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildsExpandState>>(aspect => aspect.AddExpandState(BuildsExpandState.IncludingVariables));
            return this;
        }

        public IBuildsRequest IncludingStages()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildsExpandState>>(aspect => aspect.AddExpandState(BuildsExpandState.IncludingStages));
            return this;
        }

        protected override string GetRootElement()
        {
            return "results";
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