using PandaSharp.Attributes;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Common.Request;
using PandaSharp.Services.Search.Contract;
using PandaSharp.Services.Search.Response;
using RestSharp;

namespace PandaSharp.Services.Search.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IPlanSearchParameterAspect))]
    internal sealed class PlanSearchRequest : RequestBase<PlanSearchResultsResponse>, IPlanSearchRequest
    {
        public PlanSearchRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IPlanSearchRequest WithMaxResult(int maxResult)
        {
            ApplyToAspect<IResultCountParameterAspect>(aspect => aspect.MaxResults = maxResult);
            return this;
        }

        public IPlanSearchRequest StartAtIndex(int startIndex)
        {
            ApplyToAspect<IResultCountParameterAspect>(aspect => aspect.StartIndex = startIndex);
            return this;
        }

        public IPlanSearchRequest WithSearchTerm(string searchTerm)
        {
            ApplyToAspect<IPlanSearchParameterAspect>(aspect => aspect.SearchTerm = searchTerm);
            return this;
        }

        public IPlanSearchRequest PerformFuzzySearch()
        {
            ApplyToAspect<IPlanSearchParameterAspect>(aspect => aspect.PerformFuzzySearch = true);
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