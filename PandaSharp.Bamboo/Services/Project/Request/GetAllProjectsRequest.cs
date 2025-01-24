using System;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Response;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Request
{
    [SupportsParameterAspect(typeof(IGetAllProjectsParameterAspect))]
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    internal sealed class GetAllProjectsRequest : RequestBase<ProjectListResponse>, IGetAllProjectsRequest
    {
        public GetAllProjectsRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
        }

        public IGetAllProjectsRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().SetMaxResults(maxResult);
            return this;
        }

        public IGetAllProjectsRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().SetStartIndex(startIndex);
            return this;
        }

        public IGetAllProjectsRequest IncludeEmptyProjects()
        {
            GetAspect<IGetAllProjectsParameterAspect>().SetIncludeEmptyProjects(true);
            return this;
        }

        public IGetAllProjectsRequest IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions)
        {
            GetAspect<IGetAllProjectsParameterAspect>().IncludePlanInformation(expansions);
            return this;
        }

        protected override string GetResourcePath()
        {
            return "project";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
