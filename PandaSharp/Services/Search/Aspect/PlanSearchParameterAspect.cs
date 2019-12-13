using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Search.Contract;
using RestSharp;

namespace PandaSharp.Services.Search.Aspect
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