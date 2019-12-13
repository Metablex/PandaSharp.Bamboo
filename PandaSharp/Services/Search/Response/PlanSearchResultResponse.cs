using RestSharp.Deserializers;

namespace PandaSharp.Services.Search.Response
{
    public sealed class PlanSearchResultResponse
    {
        [DeserializeAs(Name = "searchEntity")]
        public PlanSearchResultEntityResponse SearchResult { get; set; }
    }
}