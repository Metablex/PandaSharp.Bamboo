using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Response;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Request
{
    [SupportsParameterAspect(typeof(IGetAllProjectsParameterAspect))]
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    internal sealed class GetAllProjectsRequest : RequestBase<ProjectListResponse>, IGetAllProjectsRequest
    {
        public GetAllProjectsRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IGetAllProjectsRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResult;
            return this;
        }

        public IGetAllProjectsRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().StartIndex = startIndex;
            return this;
        }

        public IGetAllProjectsRequest IncludeEmptyProjects()
        {
            GetAspect<IGetAllProjectsParameterAspect>().IncludeEmptyProjects = true;
            return this;
        }

        public IGetAllProjectsRequest IncludePlanInformation()
        {
            GetAspect<IGetAllProjectsParameterAspect>().IncludePlanInformation = true;
            return this;
        }

        protected override string GetResourcePath()
        {
            return "project";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}