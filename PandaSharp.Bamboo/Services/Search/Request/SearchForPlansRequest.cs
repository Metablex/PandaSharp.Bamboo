using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Search.Aspect;
using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Bamboo.Services.Search.Response;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Search.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IPlanSearchParameterAspect))]
    internal sealed class SearchForPlansRequest : RequestBase<PlanSearchResultListResponse>, ISearchForPlansRequest
    {
        public SearchForPlansRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverter restResponseConverter)
            : base(restClientFactory, parameterAspectFactory, restResponseConverter)
        {
        }

        public ISearchForPlansRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().SetMaxResults(maxResult);
            return this;
        }

        public ISearchForPlansRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().SetStartIndex(startIndex);
            return this;
        }

        public ISearchForPlansRequest WithSearchTerm(string searchTerm)
        {
            GetAspect<IPlanSearchParameterAspect>().SetSearchTerm(searchTerm);
            return this;
        }

        public ISearchForPlansRequest PerformFuzzySearch()
        {
            GetAspect<IPlanSearchParameterAspect>().SetPerformFuzzySearch(true);
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