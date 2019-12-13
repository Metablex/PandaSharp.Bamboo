using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Search.Response;

namespace PandaSharp.Services.Search.Contract
{
    public interface IPlanSearchRequest : IRequestBase<PlanSearchResultsResponse>
    {
        IPlanSearchRequest WithMaxResult(int maxResult);

        IPlanSearchRequest StartAtIndex(int startIndex);

        IPlanSearchRequest WithSearchTerm(string searchTerm);

        IPlanSearchRequest PerformFuzzySearch();
    }
}