using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Search.Response;

namespace PandaSharp.Bamboo.Services.Search.Contract
{
    public interface ISearchForPlansRequest : IRequestBase<PlanSearchResultListResponse>
    {
        ISearchForPlansRequest WithMaxResult(int maxResult);

        ISearchForPlansRequest StartAtIndex(int startIndex);

        ISearchForPlansRequest WithSearchTerm(string searchTerm);

        ISearchForPlansRequest PerformFuzzySearch();
    }
}