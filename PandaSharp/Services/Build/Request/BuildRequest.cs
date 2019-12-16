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
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingArtifacts);
            return this;
        }

        public IBuildRequest IncludingComments()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingComments);
            return this;
        }

        public IBuildRequest IncludingLabels()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingLabels);
            return this;
        }

        public IBuildRequest IncludingJiraIssues()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingJiraIssues);
            return this;
        }

        public IBuildRequest IncludingVariables()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingVariables);
            return this;
        }

        public IBuildRequest IncludingStages()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingStages);
            return this;
        }

        public IBuildRequest IncludingChanges()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingChanges);
            return this;
        }

        public IBuildRequest IncludingMetaData()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingMetaData);
            return this;
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