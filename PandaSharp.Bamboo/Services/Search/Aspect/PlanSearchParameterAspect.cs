using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Search.Contract;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Search.Aspect
{
    internal sealed class PlanSearchParameterAspect : RequestParameterAspectBase, IPlanSearchParameterAspect
    {
        public string SearchTerm { get; set; }

        public bool PerformFuzzySearch { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                restRequest.AddParameter("searchTerm", SearchTerm);
            }

            restRequest.AddParameter("fuzzy", PerformFuzzySearch);
        }
    }
}