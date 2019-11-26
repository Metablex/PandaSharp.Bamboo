using PandaSharp.Attributes;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Build.Response;
using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Common.Request;
using RestSharp;

namespace PandaSharp.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<BuildExpandState>))]
    internal sealed class BuildRequest : RequestBase<BuildResponse>, IBuildRequest
    {
        [InjectedProperty(RequestPropertyNames.ProjectKeyName)]
        public string ProjectKey { get; set; }

        [InjectedProperty(RequestPropertyNames.PlanKeyName)]
        public string PlanKey { get; set; }

        [InjectedProperty(RequestPropertyNames.BuildNumberName)]
        public string BuildNumber { get; set; }

        public BuildRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IBuildRequest IncludingArtifacts()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildExpandState>>(aspect => aspect.AddExpandState(BuildExpandState.IncludingArtifacts));
            return this;
        }

        public IBuildRequest IncludingComments()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildExpandState>>(aspect => aspect.AddExpandState(BuildExpandState.IncludingComments));
            return this;
        }

        public IBuildRequest IncludingLabels()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildExpandState>>(aspect => aspect.AddExpandState(BuildExpandState.IncludingLabels));
            return this;
        }

        public IBuildRequest IncludingJiraIssues()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildExpandState>>(aspect => aspect.AddExpandState(BuildExpandState.IncludingJiraIssues));
            return this;
        }

        public IBuildRequest IncludingVariables()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildExpandState>>(aspect => aspect.AddExpandState(BuildExpandState.IncludingVariables));
            return this;
        }

        public IBuildRequest IncludingStages()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildExpandState>>(aspect => aspect.AddExpandState(BuildExpandState.IncludingStages));
            return this;
        }

        public IBuildRequest IncludingChanges()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildExpandState>>(aspect => aspect.AddExpandState(BuildExpandState.IncludingChanges));
            return this;
        }

        public IBuildRequest IncludingMetaData()
        {
            ApplyToAspect<IExpandStateParameterAspect<BuildExpandState>>(aspect => aspect.AddExpandState(BuildExpandState.IncludingMetaData));
            return this;
        }

        protected override string GetRootElement()
        {
            return "results";
        }

        protected override string GetResourcePath()
        {
            return $"result/{ProjectKey}-{PlanKey}-{BuildNumber}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}