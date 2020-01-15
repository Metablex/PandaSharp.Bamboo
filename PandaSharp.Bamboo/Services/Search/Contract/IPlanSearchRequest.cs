using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Search.Response;

namespace PandaSharp.Bamboo.Services.Search.Contract
{
    public interface IPlanSearchRequest : IRequestBase<PlanSearchResultListResponse>
    {
        IPlanSearchRequest WithMaxResult(int maxResult);

        IPlanSearchRequest StartAtIndex(int startIndex);

        IPlanSearchRequest WithSearchTerm(string searchTerm);

        IPlanSearchRequest PerformFuzzySearch();
    }
}