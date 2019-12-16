using Newtonsoft.Json;

namespace PandaSharp.Services.Search.Response
{
    public sealed class PlanSearchResultResponse
    {
        [JsonProperty("searchEntity")]
        public PlanSearchResultEntityResponse SearchResult { get; set; }
    }
}