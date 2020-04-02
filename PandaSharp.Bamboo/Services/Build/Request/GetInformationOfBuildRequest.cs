using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IExpandStateParameterAspect<BuildExpandState>))]
    internal sealed class GetInformationOfBuildRequest : BuildRequestBase<BuildResponse>, IGetInformationOfBuildRequest
    {
        public GetInformationOfBuildRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IGetInformationOfBuildRequest IncludingArtifacts()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingArtifacts);
            return this;
        }

        public IGetInformationOfBuildRequest IncludingComments()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingComments);
            return this;
        }

        public IGetInformationOfBuildRequest IncludingLabels()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingLabels);
            return this;
        }

        public IGetInformationOfBuildRequest IncludingJiraIssues()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingJiraIssues);
            return this;
        }

        public IGetInformationOfBuildRequest IncludingVariables()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingVariables);
            return this;
        }

        public IGetInformationOfBuildRequest IncludingStages()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingStages);
            return this;
        }

        public IGetInformationOfBuildRequest IncludingChanges()
        {
            GetAspect<IExpandStateParameterAspect<BuildExpandState>>().AddExpandState(BuildExpandState.IncludingChanges);
            return this;
        }

        public IGetInformationOfBuildRequest IncludingMetaData()
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