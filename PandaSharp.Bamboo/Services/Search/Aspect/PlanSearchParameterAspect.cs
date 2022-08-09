using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Search.Aspect
{
    internal sealed class PlanSearchParameterAspect : RequestParameterAspectBase, IPlanSearchParameterAspect
    {
        private string _searchTerm;
        private bool _performFuzzySearch;

        public void SetSearchTerm(string searchTerm)
        {
            _searchTerm = searchTerm;
        }

        public void SetPerformFuzzySearch(bool performFuzzySearch)
        {
            _performFuzzySearch = performFuzzySearch;
        }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest
                .AddParameterIfSet("searchTerm", _searchTerm)
                .AddParameter("fuzzy", _performFuzzySearch);
        }
    }
}