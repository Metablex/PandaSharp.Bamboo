using PandaSharp.Bamboo.Services.Search.Response;
using PandaSharp.Framework.Services.Contract;

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