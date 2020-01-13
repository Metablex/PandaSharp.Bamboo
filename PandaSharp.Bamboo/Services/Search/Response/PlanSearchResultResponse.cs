using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Search.Response
{
    public sealed class PlanSearchResultResponse
    {
        [JsonProperty("searchEntity")]
        public PlanSearchResultEntityResponse SearchResult { get; set; }
    }
}