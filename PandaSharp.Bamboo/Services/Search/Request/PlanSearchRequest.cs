using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Search.Aspect;
using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Bamboo.Services.Search.Response;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Search.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IPlanSearchParameterAspect))]
    internal sealed class PlanSearchRequest : RequestBase<PlanSearchResultListResponse>, IPlanSearchRequest
    {
        public PlanSearchRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IPlanSearchRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResult;
            return this;
        }

        public IPlanSearchRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().StartIndex = startIndex;
            return this;
        }

        public IPlanSearchRequest WithSearchTerm(string searchTerm)
        {
            GetAspect<IPlanSearchParameterAspect>().SearchTerm = searchTerm;
            return this;
        }

        public IPlanSearchRequest PerformFuzzySearch()
        {
            GetAspect<IPlanSearchParameterAspect>().PerformFuzzySearch = true;
            return this;
        }

        protected override string GetResourcePath()
        {
            return "search/plans";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}