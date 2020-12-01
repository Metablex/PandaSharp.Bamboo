using System;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Response;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Request
{
    [SupportsParameterAspect(typeof(IGetInformationOfProjectRequestAspect))]
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    internal sealed class GetInformationOfProjectRequest : RequestBase<ProjectResponse>, IGetInformationOfProjectRequest
    {
        [InjectedProperty(RequestPropertyNames.ProjectKey)]
        public string ProjectKey { get; set; }

        public GetInformationOfProjectRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IGetInformationOfProjectRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResult;
            return this;
        }

        public IGetInformationOfProjectRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().StartIndex = startIndex;
            return this;
        }

        public IGetInformationOfProjectRequest IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions)
        {
            GetAspect<IGetInformationOfProjectRequestAspect>().IncludePlanInformation(expansions);
            return this;
        }

        protected override string GetResourcePath()
        {
            return $"project/{ProjectKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}